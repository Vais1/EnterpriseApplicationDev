# 📝 Markdown to PDF Converter

A powerful, feature-rich web application for converting Markdown documents to PDF format with live preview and extensive customization options.

## ✨ Features

### Core Functionality
- **Real-time Markdown Preview** - See your formatted document as you type
- **PDF Export** - High-quality PDF generation with customizable page sizes
- **Image Support** - Embed images via URL or upload local files
- **Syntax Highlighting** - Beautiful code blocks with multiple language support
- **Page Breaks** - Control pagination with `<!-- pagebreak -->` syntax

### User Interface
- **Split-pane Editor** - Side-by-side editing and preview
- **Dark/Light Themes** - Switch between themes with preference persistence
- **Zoom Controls** - Adjust preview zoom from 50% to 200%
- **Drag & Drop** - Easy image upload via drag and drop
- **Responsive Design** - Works on desktop, tablet, and mobile devices

### Data Management
- **Auto-save** - Automatically saves your work every 30 seconds
- **Local Storage** - All data stored in your browser's localStorage
- **Template System** - Save and reuse Markdown templates
- **Image Library** - Manages uploaded images (last 10 stored)

## 🚀 Getting Started

### Installation

1. Clone or download this repository
2. Open `index.html` in a modern web browser
3. Start typing Markdown!

No build process, no dependencies to install. Everything runs client-side.

### Usage

1. **Type or paste Markdown** in the left editor pane
2. **See live preview** in the right pane
3. **Upload images** using the button or drag-and-drop
4. **Download as PDF** when ready

## 📁 Project Structure

```
markdownToPdf/
├── index.html              # Main HTML file
├── assets/
│   ├── css/
│   │   └── styles.css      # All styling
│   ├── js/
│   │   └── app.js          # Application logic
│   └── img/                # Static images (optional)
└── data/
    ├── templates/          # Saved Markdown templates
    │   └── README.md       # Template usage guide
    └── images/             # Uploaded images storage
        └── README.md       # Image storage guide
```

## ⌨️ Keyboard Shortcuts

- **Ctrl/Cmd + S** - Download PDF
- **Ctrl/Cmd + O** - Load sample document
- **Ctrl/Cmd + Shift + S** - Save as template
- **Ctrl/Cmd + Plus** - Zoom in
- **Ctrl/Cmd + Minus** - Zoom out

## 🎨 Markdown Support

### Text Formatting
```markdown
**Bold**, *Italic*, ***Bold Italic***
`Inline Code`, ~~Strikethrough~~
```

### Headers
```markdown
# H1
## H2
### H3
```

### Lists
```markdown
- Unordered list
  - Nested item
1. Ordered list
2. Second item
```

### Code Blocks
````markdown
```javascript
console.log('Hello, World!');
```
````

### Tables
```markdown
| Header 1 | Header 2 |
|----------|----------|
| Cell 1   | Cell 2   |
```

### Images
```markdown
![Alt text](https://example.com/image.jpg)
![Local Image](data:image/png;base64,...)
```

### Links
```markdown
[Link Text](https://example.com)
```

### Blockquotes
```markdown
> This is a blockquote
```

### Horizontal Rules
```markdown
---
```

### Page Breaks (PDF only)
```markdown
<!-- pagebreak -->
```

## 🔧 Configuration

### Page Sizes
Choose from:
- **A4** (210 x 297 mm)
- **Letter** (216 x 279 mm)
- **Legal** (216 x 356 mm)

### Theme
Toggle between dark and light themes. Your preference is saved automatically.

### Zoom
Adjust preview zoom from 50% to 200% for better readability.

## 💾 Data Storage

All data is stored locally in your browser's localStorage:

- **markdown_content** - Current document with timestamp
- **markdown_templates** - Saved templates
- **uploaded_images** - Last 10 uploaded images
- **theme** - Theme preference

### Storage Limits
Browser localStorage typically supports 5-10MB. The app:
- Keeps only the last 10 uploaded images
- Compresses images as base64
- Auto-saves every 30 seconds

### Clearing Data
To clear all stored data:
```javascript
localStorage.clear();
```
Run this in the browser console if needed.

## 📚 Libraries Used

- **[marked.js](https://marked.js.org/)** (v9.1.6) - Markdown parser with GFM support
- **[jsPDF](https://github.com/parallax/jsPDF)** (v2.5.1) - PDF generation
- **[html2canvas](https://html2canvas.hertzen.com/)** (v1.4.1) - HTML to canvas rendering
- **[highlight.js](https://highlightjs.org/)** (v11.8.0) - Syntax highlighting
- **[DOMPurify](https://github.com/cure53/DOMPurify)** (v3.0.6) - XSS protection

All libraries loaded via CDN - no local installation required.

## 🌐 Browser Compatibility

Works in all modern browsers:
- Chrome/Edge (v90+)
- Firefox (v88+)
- Safari (v14+)
- Opera (v76+)

**Note:** Internet connection required on first load to fetch CDN libraries.

## 🛠️ Development

### File Structure

#### index.html
Main HTML structure with CDN library imports.

#### assets/css/styles.css
Complete styling including:
- Dark/light theme variables
- Responsive design
- Markdown preview styling
- UI components

#### assets/js/app.js
Application logic including:
- Markdown parsing and preview
- PDF generation
- Image upload handling
- Local storage management
- Keyboard shortcuts

### Customization

#### Adding Custom Styles
Edit `assets/css/styles.css` to customize:
- Colors (CSS variables in `:root`)
- Fonts
- Spacing
- Component styling

#### Adding Features
Edit `assets/js/app.js` to add:
- New markdown extensions
- Custom export formats
- Additional shortcuts
- Enhanced storage

## 📝 Tips & Best Practices

1. **Optimize Images** - Compress images before uploading to reduce file size
2. **Use External URLs** - For large images, use URLs instead of uploads
3. **Save Templates** - Create templates for frequently used document structures
4. **Regular Exports** - Download PDFs regularly as backup
5. **Clear Storage** - Periodically clear old images to free up space

## 🐛 Troubleshooting

### PDF Generation Fails
- Ensure all images are fully loaded
- Try reducing image sizes
- Check browser console for errors

### Images Not Displaying
- Verify image format is supported (PNG, JPG, GIF, SVG, WebP)
- Check if images are accessible (CORS issues for external URLs)
- Try uploading as base64 instead

### Storage Quota Exceeded
- Clear old images: `localStorage.removeItem('uploaded_images')`
- Use external image URLs
- Export and start fresh

### Preview Not Updating
- Check browser console for JavaScript errors
- Refresh the page
- Clear browser cache

## 📄 License

This project is open source and available for personal and commercial use.

## 🤝 Contributing

Contributions welcome! Areas for improvement:
- Additional export formats (DOCX, HTML)
- Cloud storage integration
- Real-time collaboration
- Enhanced template system
- Mobile app version

## 📧 Support

For issues, questions, or suggestions:
1. Check the troubleshooting section
2. Review the data/templates and data/images READMEs
3. Open an issue in the repository

---

**Happy Converting! 🎉**

*Built with ❤️ using modern web technologies*
