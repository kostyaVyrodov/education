# Notes about HTML

## HTML

**HTML** is markup language for defining page structure;
**XHTML** is extension for HTML. It contains additional tags for page styling;
**HTML5** is based on HTML 4.01. It provides additional semantic tags.

A browser ignores all unknown tags;

### HTML boolean attributes

- ```checked``` indicates selection in checkbox or option button;
- ```selected``` indicates selected item in drop-down or select list;
- ```disabled``` indicates disabling of UI controls;
- ```readonly``` prevents the user from typing data into a text box.

### HTML5 global attribute

- ```dir``` enables RTL or LTR text direction;
- ```hidden``` hides element;
- ```draggable``` and ```dropzone``` are used for implementation dnd;
- ```lang``` specifies used lang;
- ```data-<some-info>``` is expando attribute that allows a developer to add additional data to markup;

## Embedding content

### Frames 

To  embed an inline frame that contains an HTML within the current HTML  use the ```<iframe>```

```<iframe src="menu.html"></iframe>```

The ```sandbox``` attribute places a set of extra restrictions on any content hosted by the iframe.
- ```allow-forms``` enables forms;
- ```allow-same-origin``` allows the content to be treated as being from the same origin instead of forcing it into a unique origin;
- ```allow-scripts``` enables scripts except pop-ups;
- ```allow-top-navigation``` allows the content to navigate its top-level browsing context.


The ```seamless``` attribute says that a frame is part of the page and a browser needs to render it without scrollbar and borders. 

### Hyperlinks

Types of links: 
- Unvisited is blue;
- Visited is purple;
- Active is red.

Link's targets:
- ```target="blank"``` opens the link in a new window;
- ```target="parent"``` opens the link in a parent frame;
- ```target="self"``` opens the link in the current window (default);
- ```target="self"``` opens the link in the in the topmost frame;

Sending email with hyperlink: 

```<a href="mailto:Joe&lt;sales@contoso.com&gt?cc=<copies>&subject=hi&body=call me.">Contact Joe in Sales</a>```

'Image map' is clickable area on an image. 

```<object/>``` defines an embedded object. It can be a .gif, .svg, video, pdf or something else.