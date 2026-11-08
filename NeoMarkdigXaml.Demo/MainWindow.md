# Document Title

To create a heading, add one to six # symbols before your heading text. 

## Headings
### A third-level heading
#### A forth-level heading
##### A fifth-level heading
###### A sixth-level heading

## Styling text

Bold: **This is bold text**  
Italic: _This text is italicized_  
Bold and nested italic: **This text is _extremely_ important**  
All bold and italic: ***All this text is important***  

## Quoting text

Below text is a quote:

> This is a blockquote. It is used to highlight quotes, notes, or external references.

## Code

If you want to reference `inline code`, wrap it in single backticks. For larger blocks of code, use a fenced code block with three backticks:

```python
def greet(name):
    print(f"Hello, {name}!")
```

## Links

Auto link:
<https://commonmark.org>

You can easily insert [inline links with text](https://commonmark.org) that direct to websites. 

## Line breaks

Include two spaces at the end of the first line.  
Second line

Include a backslash at the end of the first line.\
Second line

## Images

To include an web image, use an exclamation mark followed by alt text and the image URL:

![alt text](https://github.com/adam-p/markdown-here/raw/master/src/common/images/icon48.png "Logo Title Text 1")

And local image with defined size:

![Local image](sampleimage.jpg "Local image"){width=100}


## Lists

### Ordered List

1. Item 1
1. Item 2
1. Item 3

### Unordered List

- **First item**: Use a hyphen, plus, or asterisk.
- **Second item**: Keep a space after the marker.
  - **Indented item**: Indent by four spaces or one tab.

## Horizontal rule

You can separate your section with horizontal ruler.

---
Continue text after ruler.

# Extensions

## Emphasis extras

Strikethrough: ~~This was mistaken text~~\
Subscript: H~2~O is water.\
Superscript: 2^10^ is 1024.\
Inserted text: This text has been ++inserted++.\
Marked/highlighted text: This is ==highlighted== text.

## Tables

### Pipe table

Below is a table demonstrating left, center, and right text justification as supported by extended CommonMark processors.

| Left-Aligned | Center-Aligned | Right-Aligned | Default |
| :--- | :---: | ---: | --- |
| Text is flushed left. | Text is centered. | Text is flushed right. | Standard alignment. |
| Short | Medium Text | `$1,200.00` | Normal |
| Aligns left by default or with `:---`. | Colon on both sides `:---:`. | Colon on the right side `---:`. | No colons used. |

### Grid table

+-----------+-------------------+
| Name      | Description       |
+===========+===================+
| Markdig   | A fast, powerful  |
|           | Markdown parser.  |
+-----------+-------------------+
| cmark     | The C reference   |
|           | implementation.   |
+-----------+-------------------+
| Column spanning               |
+-----------+-------------------+

## Task Lists

- [x] Write documentation
- [x] Implement feature
- [ ] Write tests
- [ ] Release

## Alerts

Alerts, also sometimes known as callouts or admonitions, are a Markdown extension based on the blockquote syntax that you can use to emphasize critical information.

> [!NOTE]
> Useful information that users should know, even when skimming content.

> [!TIP]
> Helpful advice for doing things better or more easily.

> [!IMPORTANT]
> Key information users need to know to achieve their goal.

> [!WARNING]
> Urgent info that needs immediate user attention to avoid problems.

> [!CAUTION]
> Advises about risks or negative outcomes of certain actions.
