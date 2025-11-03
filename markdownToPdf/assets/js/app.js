// Configure marked.js
marked.setOptions({
    breaks: true,
    gfm: true,
    highlight: function(code, lang) {
        if (lang && hljs.getLanguage(lang)) {
            try {
                return hljs.highlight(code, { language: lang }).value;
            } catch (err) {}
        }
        return hljs.highlightAuto(code).value;
    }
});

// State
let zoomLevel = 1;
const previewContainer = document.getElementById('preview-container');
const preview = document.getElementById('preview');
const markdownInput = document.getElementById('markdown-input');
const downloadBtn = document.getElementById('download-pdf');
const loadSampleBtn = document.getElementById('load-sample');
const mdFileInput = document.getElementById('md-file-input');
const imageInput = document.getElementById('image-input');
const themeToggle = document.getElementById('theme-toggle');
const pageSizeSelect = document.getElementById('page-size');
const statusMessage = document.getElementById('status-message');
const loading = document.getElementById('loading');
const zoomInBtn = document.getElementById('zoom-in');
const zoomOutBtn = document.getElementById('zoom-out');
const zoomLevelSpan = document.getElementById('zoom-level');

// Sample Markdown with images
const sampleMarkdown = `# Markdown to PDF Converter Demo

## Introduction
This is a **comprehensive** demonstration of the Markdown to PDF converter with *various formatting options*.

## Features

### Text Formatting
- **Bold text** for emphasis
- *Italic text* for style
- ***Bold and italic*** for extra emphasis
- \`inline code\` for technical terms
- ~~Strikethrough~~ for deleted content

### Lists

#### Unordered List
- First item
- Second item
  - Nested item 1
  - Nested item 2
- Third item

#### Ordered List
1. First step
2. Second step
3. Third step

### Code Blocks

#### JavaScript Example
\`\`\`javascript
function greet(name) {
    console.log(\`Hello, \${name}!\`);
}

greet('World');
\`\`\`

#### Python Example
\`\`\`python
def fibonacci(n):
    if n <= 1:
        return n
    return fibonacci(n-1) + fibonacci(n-2)

print(fibonacci(10))
\`\`\`

### Tables

| Feature | Supported | Notes |
|---------|-----------|-------|
| Headers | ✅ | H1-H6 |
| Lists | ✅ | Ordered & Unordered |
| Code | ✅ | Inline & Blocks |
| Images | ✅ | Local & URLs |
| Tables | ✅ | Full support |

### Links

- [Google](https://www.google.com)
- [GitHub](https://github.com)
- [Markdown Guide](https://www.markdownguide.org)

### Images

![Placeholder Image](https://via.placeholder.com/600x300/007acc/ffffff?text=Sample+Image)

### Blockquotes

> "The best way to predict the future is to invent it."
> - Alan Kay

> **Note:** This converter supports most Markdown features including:
> - GFM (GitHub Flavored Markdown)
> - Syntax highlighting
> - Tables and task lists

### Horizontal Rules

---

### Page Breaks

Use \`<!-- pagebreak -->\` to insert a page break in your PDF.

<!-- pagebreak -->

## Second Page

This content appears on a new page in the PDF!

### Mathematical Expressions

Although not rendered here, you can add mathematical notation:
- Inline: \`E = mc²\`
- Block equations can be added with proper syntax

### Task Lists

- [x] Create Markdown to PDF converter
- [x] Add image support
- [x] Implement live preview
- [ ] Add more features
- [ ] Write documentation

## Conclusion

This Markdown to PDF converter supports a wide range of formatting options, making it perfect for creating professional documents, reports, and documentation.

**Happy Converting! 🎉**

---

*Generated on ${new Date().toLocaleDateString()}*
`;

// Initialize with empty content
updatePreview();
loadFromLocalStorage();

// Event Listeners
markdownInput.addEventListener('input', debounce(() => {
    updatePreview();
    saveToLocalStorage();
}, 300));

downloadBtn.addEventListener('click', generatePDF);
loadSampleBtn.addEventListener('click', loadSample);
mdFileInput.addEventListener('change', loadMarkdownFile);
imageInput.addEventListener('change', handleImageUpload);
themeToggle.addEventListener('click', toggleTheme);
zoomInBtn.addEventListener('click', () => adjustZoom(0.1));
zoomOutBtn.addEventListener('click', () => adjustZoom(-0.1));

// Auto-save timer
setInterval(saveToLocalStorage, 30000); // Auto-save every 30 seconds

// Functions
function updatePreview() {
    try {
        const markdown = markdownInput.value;
        let html = marked.parse(markdown);
        
        // Sanitize HTML
        html = DOMPurify.sanitize(html);
        
        // Handle page breaks
        html = html.replace(/<!-- pagebreak -->/g, '<div class="page-break"></div>');
        
        preview.innerHTML = html;
        
        // Highlight code blocks
        preview.querySelectorAll('pre code').forEach((block) => {
            hljs.highlightElement(block);
        });
        
    } catch (error) {
        showStatus('Error parsing Markdown: ' + error.message, 'error');
        console.error(error);
    }
}

async function generatePDF() {
    try {
        showLoading(true);
        downloadBtn.disabled = true;
        
        // Wait for all images to load
        await waitForImagesToLoad();
        
        // Get page size
        const pageSize = pageSizeSelect.value.toUpperCase();
        const pageDimensions = {
            'A4': { width: 210, height: 297 },
            'LETTER': { width: 216, height: 279 },
            'LEGAL': { width: 216, height: 356 }
        };
        
        const dims = pageDimensions[pageSize] || pageDimensions['A4'];
        
        // Create canvas from preview
        const canvas = await html2canvas(preview, {
            scale: 2,
            useCORS: true,
            allowTaint: true,
            backgroundColor: '#ffffff',
            logging: false
        });
        
        // Initialize jsPDF
        const { jsPDF } = window.jspdf;
        const pdf = new jsPDF({
            orientation: 'portrait',
            unit: 'mm',
            format: pageSize.toLowerCase()
        });
        
        const imgWidth = dims.width - 20; // 10mm margin on each side
        const pageHeight = dims.height - 20; // 10mm margin top and bottom
        const imgHeight = (canvas.height * imgWidth) / canvas.width;
        
        let heightLeft = imgHeight;
        let position = 10; // 10mm top margin
        
        // Add image to PDF
        const imgData = canvas.toDataURL('image/png');
        pdf.addImage(imgData, 'PNG', 10, position, imgWidth, imgHeight);
        heightLeft -= pageHeight;
        
        // Add new pages if content is longer than one page
        while (heightLeft > 0) {
            position = heightLeft - imgHeight + 10;
            pdf.addPage();
            pdf.addImage(imgData, 'PNG', 10, position, imgWidth, imgHeight);
            heightLeft -= pageHeight;
        }
        
        // Generate filename
        const filename = `markdown-${Date.now()}.pdf`;
        
        // Save PDF
        pdf.save(filename);
        
        showStatus('PDF downloaded successfully!', 'success');
        
    } catch (error) {
        showStatus('Error generating PDF: ' + error.message, 'error');
        console.error(error);
    } finally {
        showLoading(false);
        downloadBtn.disabled = false;
    }
}

function waitForImagesToLoad() {
    const images = preview.querySelectorAll('img');
    const promises = Array.from(images).map(img => {
        if (img.complete) return Promise.resolve();
        return new Promise((resolve, reject) => {
            img.onload = resolve;
            img.onerror = resolve; // Continue even if image fails to load
        });
    });
    return Promise.all(promises);
}

function loadSample() {
    markdownInput.value = sampleMarkdown;
    updatePreview();
    saveToLocalStorage();
    showStatus('Sample loaded!', 'success');
}

function loadMarkdownFile(event) {
    const file = event.target.files[0];
    if (!file) return;
    
    const reader = new FileReader();
    reader.onload = (e) => {
        markdownInput.value = e.target.result;
        updatePreview();
        saveToLocalStorage();
        showStatus(`File "${file.name}" loaded successfully!`, 'success');
    };
    reader.onerror = () => {
        showStatus('Error loading file', 'error');
    };
    reader.readAsText(file);
}

function handleImageUpload(event) {
    const files = event.target.files;
    if (!files.length) return;
    
    Array.from(files).forEach(file => {
        const reader = new FileReader();
        reader.onload = (e) => {
            const imageData = e.target.result;
            
            // Save image to localStorage with timestamp
            const imageId = `img_${Date.now()}_${Math.random().toString(36).substr(2, 9)}`;
            saveImageToStorage(imageId, imageData, file.name);
            
            const imageMarkdown = `\n![${file.name}](${imageData})\n`;
            const cursorPos = markdownInput.selectionStart;
            const textBefore = markdownInput.value.substring(0, cursorPos);
            const textAfter = markdownInput.value.substring(cursorPos);
            markdownInput.value = textBefore + imageMarkdown + textAfter;
            updatePreview();
            saveToLocalStorage();
            showStatus(`Image "${file.name}" uploaded!`, 'success');
        };
        reader.readAsDataURL(file);
    });
}

function toggleTheme() {
    document.body.classList.toggle('light-theme');
    const isDark = !document.body.classList.contains('light-theme');
    themeToggle.textContent = isDark ? '🌙 Toggle Theme' : '☀️ Toggle Theme';
    localStorage.setItem('theme', isDark ? 'dark' : 'light');
}

function adjustZoom(delta) {
    zoomLevel = Math.max(0.5, Math.min(2, zoomLevel + delta));
    preview.style.transform = `scale(${zoomLevel})`;
    preview.style.transformOrigin = 'top center';
    zoomLevelSpan.textContent = `${Math.round(zoomLevel * 100)}%`;
}

function showStatus(message, type) {
    statusMessage.textContent = message;
    statusMessage.className = `status-message ${type}`;
    setTimeout(() => {
        statusMessage.className = 'status-message';
    }, 3000);
}

function showLoading(show) {
    loading.classList.toggle('active', show);
}

function debounce(func, wait) {
    let timeout;
    return function executedFunction(...args) {
        const later = () => {
            clearTimeout(timeout);
            func(...args);
        };
        clearTimeout(timeout);
        timeout = setTimeout(later, wait);
    };
}

// Local Storage Functions
function saveToLocalStorage() {
    try {
        const data = {
            markdown: markdownInput.value,
            timestamp: new Date().toISOString()
        };
        localStorage.setItem('markdown_content', JSON.stringify(data));
    } catch (error) {
        console.error('Error saving to localStorage:', error);
    }
}

function loadFromLocalStorage() {
    try {
        const saved = localStorage.getItem('markdown_content');
        if (saved) {
            const data = JSON.parse(saved);
            markdownInput.value = data.markdown;
            updatePreview();
            console.log('Loaded saved content from:', data.timestamp);
        }
    } catch (error) {
        console.error('Error loading from localStorage:', error);
    }
}

function saveImageToStorage(imageId, imageData, fileName) {
    try {
        const imageInfo = {
            id: imageId,
            data: imageData,
            fileName: fileName,
            timestamp: new Date().toISOString()
        };
        
        // Get existing images
        const images = JSON.parse(localStorage.getItem('uploaded_images') || '[]');
        images.push(imageInfo);
        
        // Keep only last 10 images to prevent storage overflow
        if (images.length > 10) {
            images.shift();
        }
        
        localStorage.setItem('uploaded_images', JSON.stringify(images));
    } catch (error) {
        console.error('Error saving image to storage:', error);
    }
}

function saveTemplate(name, content) {
    try {
        const templates = JSON.parse(localStorage.getItem('markdown_templates') || '{}');
        templates[name] = {
            content: content,
            timestamp: new Date().toISOString()
        };
        localStorage.setItem('markdown_templates', JSON.stringify(templates));
        showStatus(`Template "${name}" saved!`, 'success');
    } catch (error) {
        showStatus('Error saving template', 'error');
        console.error('Error saving template:', error);
    }
}

function loadTemplate(name) {
    try {
        const templates = JSON.parse(localStorage.getItem('markdown_templates') || '{}');
        if (templates[name]) {
            markdownInput.value = templates[name].content;
            updatePreview();
            showStatus(`Template "${name}" loaded!`, 'success');
        }
    } catch (error) {
        showStatus('Error loading template', 'error');
        console.error('Error loading template:', error);
    }
}

// Load saved theme
const savedTheme = localStorage.getItem('theme');
if (savedTheme === 'light') {
    toggleTheme();
}

// Drag and drop support for images
markdownInput.addEventListener('dragover', (e) => {
    e.preventDefault();
    e.stopPropagation();
});

markdownInput.addEventListener('drop', (e) => {
    e.preventDefault();
    e.stopPropagation();
    
    const files = Array.from(e.dataTransfer.files).filter(file => 
        file.type.startsWith('image/')
    );
    
    if (files.length > 0) {
        files.forEach(file => {
            const reader = new FileReader();
            reader.onload = (event) => {
                const imageData = event.target.result;
                
                // Save image to localStorage
                const imageId = `img_${Date.now()}_${Math.random().toString(36).substr(2, 9)}`;
                saveImageToStorage(imageId, imageData, file.name);
                
                const imageMarkdown = `\n![${file.name}](${imageData})\n`;
                const cursorPos = markdownInput.selectionStart;
                const textBefore = markdownInput.value.substring(0, cursorPos);
                const textAfter = markdownInput.value.substring(cursorPos);
                markdownInput.value = textBefore + imageMarkdown + textAfter;
                updatePreview();
                saveToLocalStorage();
                showStatus(`Image "${file.name}" added!`, 'success');
            };
            reader.readAsDataURL(file);
        });
    }
});

// Keyboard shortcuts
document.addEventListener('keydown', (e) => {
    // Ctrl/Cmd + S to download PDF
    if ((e.ctrlKey || e.metaKey) && e.key === 's') {
        e.preventDefault();
        generatePDF();
    }
    
    // Ctrl/Cmd + O to load sample
    if ((e.ctrlKey || e.metaKey) && e.key === 'o') {
        e.preventDefault();
        loadSample();
    }
    
    // Ctrl/Cmd + Plus/Minus for zoom
    if (e.ctrlKey || e.metaKey) {
        if (e.key === '=' || e.key === '+') {
            e.preventDefault();
            adjustZoom(0.1);
        } else if (e.key === '-') {
            e.preventDefault();
            adjustZoom(-0.1);
        }
    }
    
    // Ctrl/Cmd + Shift + S to save template
    if ((e.ctrlKey || e.metaKey) && e.shiftKey && e.key === 'S') {
        e.preventDefault();
        const templateName = prompt('Enter template name:');
        if (templateName) {
            saveTemplate(templateName, markdownInput.value);
        }
    }
});

console.log('Markdown to PDF Converter initialized!');
console.log('Keyboard shortcuts:');
console.log('  Ctrl+S / Cmd+S - Download PDF');
console.log('  Ctrl+O / Cmd+O - Load Sample');
console.log('  Ctrl+Plus / Cmd+Plus - Zoom In');
console.log('  Ctrl+Minus / Cmd+Minus - Zoom Out');
console.log('  Ctrl+Shift+S / Cmd+Shift+S - Save Template');
console.log('\nData is automatically saved to localStorage every 30 seconds and on changes.');
