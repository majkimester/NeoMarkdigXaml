# Document Title

This is a standard paragraph. You can format text to be *italicized* and **bolded**.

## Tables and Extensions

Below is a table demonstrating left, center, and right text justification as supported by extended CommonMark processors.

| Left-Aligned | Center-Aligned | Right-Aligned | Default |
| :--- | :---: | ---: | --- |
| Text is flushed left. | Text is centered. | Text is flushed right. | Standard alignment. |
| Short | Medium Text | `$1,200.00` | Normal |
| Aligns left by default or with `:---`. | Colon on both sides `:---:`. | Colon on the right side `---:`. | No colons used. |

## Section Title

This section demonstrates other standard features and extra extensions.

### Horizontal rule

---

### Heading 3 (Lists)

#### Ordered List

1. Item 1
1. Item 2
    * One
    * Two
1. Item 3

#### Unordered List

- **First item**: Use a hyphen, plus, or asterisk.
- **Second item**: Keep a space after the marker.
  - **Nested item**: Indent by four spaces or one tab.

#### Task Lists (Extension Support)

- [x] This is a completed task
- [ ] This is an incomplete task

### Blockquotes

> This is a blockquote. It is used to highlight quotes, notes, or external references. 

### Code

If you want to reference `inline code`, wrap it in single backticks. For larger blocks of code, use a fenced code block with three backticks:

```python
def greet(name):
    print(f"Hello, {name}!")
```

## Links and Images

Auto link:
<https://commonmark.org>

You can easily insert [inline links with text](https://commonmark.org) that direct to websites. 

To include an web image, use an exclamation mark followed by alt text and the image URL:

![alt text](https://github.com/adam-p/markdown-here/raw/master/src/common/images/icon48.png "Logo Title Text 1")

And local image:

![Local image](sampleimage.jpg "Local image")


## Hard Line Breaks
To force a line break within a paragraph, add two or more spaces at the end of a line  
and then hit enter to start the next line.