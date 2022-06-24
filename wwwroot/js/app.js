window.highlightCode = (sourceCode, language) => {
    return hljs.highlight(sourceCode, { language }).value;
}