# Quick Start Guide

## 🚀 Getting Started (2 Minutes)

1. **Open** `index.html` in your browser
2. **Start typing** Markdown in the left pane
3. **See preview** in the right pane
4. **Click "Download PDF"** when ready!

## 📝 Quick Markdown Reference

### Basics
```markdown
**bold** *italic* ***both***
`code` ~~strike~~
```

### Headers
```markdown
# H1
## H2
### H3
```

### Lists
```markdown
- Bullet point
  - Nested bullet

1. Numbered item
2. Second item
```

### Links & Images
```markdown
[Link text](https://url.com)
![Image alt](image-url.jpg)
```

### Code Blocks
````markdown
```javascript
console.log('Hello!');
```
````

### Tables
```markdown
| Header 1 | Header 2 |
|----------|----------|
| Cell 1   | Cell 2   |
```

### Blockquotes
```markdown
> This is a quote
```

### Page Breaks (PDF)
```markdown
<!-- pagebreak -->
```

## ⌨️ Keyboard Shortcuts

| Shortcut | Action |
|----------|--------|
| `Ctrl/Cmd + S` | Download PDF |
| `Ctrl/Cmd + O` | Load Sample |
| `Ctrl/Cmd + Shift + S` | Save Template |
| `Ctrl/Cmd + Plus` | Zoom In |
| `Ctrl/Cmd + Minus` | Zoom Out |

## 🎨 Features

- ✅ **Auto-save** - Your work is saved every 30 seconds
- ✅ **Dark/Light theme** - Toggle with button or system preference
- ✅ **Drag & Drop** - Drop images directly into editor
- ✅ **Multiple page sizes** - A4, Letter, Legal
- ✅ **Zoom controls** - 50% to 200%

## 📁 File Locations

```
markdownToPdf/
├── index.html          # Main app
├── assets/
│   ├── css/
│   │   └── styles.css  # All styles
│   └── js/
│       └── app.js      # All JavaScript
└── data/
    ├── templates/      # Saved templates
    └── images/         # Uploaded images
```

## 💡 Pro Tips

1. **Use templates** - Load pre-built templates from `data/templates/`
2. **Optimize images** - Compress before uploading
3. **Page breaks** - Use `<!-- pagebreak -->` for multi-page PDFs
4. **External images** - Use URLs for large images
5. **Regular exports** - Download PDFs as backups

## 🔧 Settings

### Change Page Size
Use dropdown in bottom toolbar:
- A4 (210 x 297 mm)
- Letter (216 x 279 mm)
- Legal (216 x 356 mm)

### Zoom Preview
Use +/- buttons or keyboard shortcuts

### Switch Theme
Click moon/sun icon in header

## 📚 Template Usage

### Load Template
1. Open a `.md` file from `data/templates/`
2. Copy content
3. Paste in editor

### Save Template
1. Type your Markdown
2. Press `Ctrl/Cmd + Shift + S`
3. Enter template name

Available templates:
- `project-report.md` - Formal project report
- `meeting-notes.md` - Meeting minutes
- `technical-documentation.md` - API/Technical docs

## 🖼️ Image Handling

### Upload Images
1. Click "🖼️ Upload Image" button
2. Or drag & drop into editor
3. Image embedded as base64

### External Images
```markdown
![Image](https://via.placeholder.com/400x200)
```

### Local Images
Uploaded images stored in browser localStorage (last 10 kept)

## 💾 Data Storage

All data saved in browser localStorage:
- **Content** - Current Markdown document
- **Templates** - Saved templates
- **Images** - Last 10 uploaded images
- **Settings** - Theme preference, zoom level

### Clear Data
Open browser console (F12) and run:
```javascript
localStorage.clear();
```

## 🐛 Troubleshooting

### PDF Won't Download
- Wait for images to load
- Reduce image sizes
- Check browser console for errors

### Preview Not Updating
- Refresh page
- Clear browser cache
- Check JavaScript console

### Storage Full
- Clear old images: `localStorage.removeItem('uploaded_images')`
- Use external image URLs
- Export and start fresh

## 📱 Mobile Usage

Works on mobile browsers:
- Split view becomes vertical
- Touch-friendly controls
- All features available

## 🌐 Browser Support

- Chrome/Edge 90+
- Firefox 88+
- Safari 14+
- Opera 76+

Requires internet on first load (CDN libraries).

## 📖 Full Documentation

See `README.md` for complete documentation including:
- Detailed feature list
- Architecture details
- API reference
- Contributing guidelines
- Advanced customization

## 🆘 Need Help?

1. Check this guide
2. Read `README.md`
3. Check `data/templates/README.md` for template help
4. Check `data/images/README.md` for image help
5. Open browser console (F12) for errors

---

**Happy Converting! 🎉**

*Quick Start Guide v1.0*
