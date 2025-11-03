# Changelog

All notable changes to the Markdown to PDF Converter project will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.0] - 2025-11-03

### Added
- Initial release of Markdown to PDF Converter
- Real-time Markdown preview with marked.js
- PDF export functionality with jsPDF and html2canvas
- Split-pane editor interface
- Dark and light theme support with persistence
- Zoom controls (50% - 200%)
- Image upload with drag-and-drop support
- Auto-save functionality (every 30 seconds)
- Local storage integration for data persistence
- Template system for saving and loading Markdown templates
- Keyboard shortcuts for common actions
- Page size options (A4, Letter, Legal)
- Syntax highlighting for code blocks with highlight.js
- XSS protection with DOMPurify
- Page break support for PDFs using `<!-- pagebreak -->`
- Responsive design for mobile and tablet devices
- Sample Markdown document loader
- Status messages for user feedback
- Loading indicator during PDF generation

### Documentation
- Comprehensive README.md with full feature documentation
- Quick Start Guide (QUICK_START.md)
- Template examples (project-report.md, meeting-notes.md, technical-documentation.md)
- Data directory structure with README files
- .gitignore file for version control

### Project Structure
- Separated CSS into assets/css/styles.css
- Separated JavaScript into assets/js/app.js
- Created data/templates/ directory for template storage
- Created data/images/ directory for image management
- Clean, modular file organization

### Features
- GFM (GitHub Flavored Markdown) support
- Tables, task lists, and strikethrough support
- Embedded images (base64 and URLs)
- Multiple Markdown file format support (.md, .markdown, .txt)
- Browser localStorage for data persistence
- Image library management (last 10 images)
- Template management system
- Theme preference persistence

### Technical
- Client-side only implementation (no server required)
- CDN-based library loading
- HTML5, CSS3, and ES6+ JavaScript
- Cross-browser compatibility
- No build process required

## [Unreleased]

### Planned Features
- Additional export formats (DOCX, HTML)
- Cloud storage integration
- Enhanced template manager UI
- Markdown table editor
- Image optimization tools
- Print stylesheet
- Custom fonts for PDF export
- Batch PDF generation
- Markdown validation
- Spell checker
- Word count and reading time
- Full-screen mode
- Split-screen layout options
- Custom CSS injection for PDF
- Watermark support
- PDF encryption options

### Under Consideration
- Real-time collaboration features
- Server-side rendering option
- Desktop application (Electron)
- Mobile native apps
- Browser extension version
- Version history/undo system
- Export to other formats (ePub, LaTeX)
- Integration with cloud storage providers
- Markdown snippet library
- AI-powered writing assistance

## Version History

### Version Numbering
- **Major.Minor.Patch** (e.g., 1.0.0)
- **Major**: Breaking changes or major new features
- **Minor**: New features, backward compatible
- **Patch**: Bug fixes and minor improvements

### Release Schedule
- Major versions: As needed for significant changes
- Minor versions: Monthly for new features
- Patch versions: As needed for bug fixes

## Contributing

To contribute to this changelog:
1. Add entries under [Unreleased] section
2. Use categories: Added, Changed, Deprecated, Removed, Fixed, Security
3. Keep entries concise and user-focused
4. Link to issues/PRs when applicable

---

**Legend:**
- `Added` - New features
- `Changed` - Changes to existing functionality
- `Deprecated` - Features to be removed in future
- `Removed` - Removed features
- `Fixed` - Bug fixes
- `Security` - Security improvements

---

*Last updated: 2025-11-03*
