# Notes about CSS

What's new in CSS3?

- Media Queries - adapting HTML basing on conditions such as screen;
- Color type

## Introducing CSS3

'media' attr allows to specify when to apply the stylesheet 

```<link rel='stylesheet' type='text/css' href='Content/printer.css' media='print' />```

Specifying encoding of css file (can be useful if the file received not from server and encoding is not specified)

- In css file: ```@charset 'UTF-8';```
- In html file (using meta tags): ```<meta http-equiv='Content-Type' content='text/html;charset=UTF-8'>```

> Note: '@' is at-rule. It's used for defining @font-family, @charset and other
