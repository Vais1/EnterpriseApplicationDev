# Images Directory

This directory is for storing uploaded images.

## Usage

Images can be added to your Markdown documents in several ways:
1. Click the "🖼️ Upload Image" button
2. Drag and drop images directly into the editor
3. Use the file input to select multiple images

## Storage

Images are stored in the browser's localStorage as base64-encoded data strings under the key `uploaded_images`.

**Note:** Due to browser localStorage limitations (typically 5-10MB), only the last 10 uploaded images are kept in storage.

## Image Formats Supported

- PNG
- JPEG/JPG
- GIF
- SVG
- WebP
- BMP

## Best Practices

1. **Optimize images** before uploading to reduce file size
2. **Use URLs** for large images when possible
3. **Export documents** regularly to save your work with embedded images
4. For large projects, consider hosting images externally and using URLs

## Clearing Image Storage

To clear stored images and free up space:
```javascript
localStorage.removeItem('uploaded_images');
```

Run this in the browser console if you need to reset image storage.
