# React

## React Top-Level API

A **Component** allows to split UI into independent and reusable pieces. A component can be a class or function. A **component** can be **pure** and it's better to use **React.memo** for **function components** and to use **React.PureComponent** for **class components**

`render()` function of component or function based component returns elements.

**React.createRef** creates ref that can be attached to a child

```js
class MyComponent extends React.Component {
  constructor(props) {
    super(props);

    this.inputRef = React.createRef();
  }

  render() {
    return <input type="text" ref={this.inputRef} />;
  }

  componentDidMount() {
    this.inputRef.current.focus();
  }
}
```

**React.forwardRef** creates a React component that forwards the ref attribute it receives to another component below in the tree.

```js
const FancyButton = React.forwardRef((props, ref) => (
  <button ref={ref} className="FancyButton">
    {props.children}
  </button>
));

// You can now get a ref directly to the DOM button:
const ref = React.createRef();
<FancyButton ref={ref}>Click me!</FancyButton>;
```

**React.lazy** allows to load a component on demand

```js
// This component is loaded dynamically
const SomeComponent = React.lazy(() => import('./SomeComponent'));
```

**React.Suspense** displays other component during lazy loading of a component

```js
// This component is loaded dynamically
const OtherComponent = React.lazy(() => import('./OtherComponent'));

function MyComponent() {
  return (
    // Displays <Spinner> until OtherComponent loads
    <React.Suspense fallback={<Spinner />}>
      <div>
        <OtherComponent />
      </div>
    </React.Suspense>
  );
}
```

## React.Component

**Mounting**

- `constructor()`
- `static getDerivedStateFromProps(props, state)` - is invoked right before calling the render method. It enables a component to update its internal state as the result of changes in props.
- `render()`
- `componentDidMount()`

**Updating**

- `static getDerivedStateFromProps()`
- `shouldComponentUpdate()`
- `render()`
- `getSnapshotBeforeUpdate()` is invoked right before the most recently rendered output is committed to e.g. the DOM. It enables your component to capture some information from the DOM (e.g. scroll position) before it is potentially changed. 
- `componentDidUpdate()`

**Unmounting**

- componentWillUnmount()

**Error handling**

- `static getDerivedStateFromError()`
- `componentDidCatch()`

**Class properties**

`displayName` is used as a debug name of component


## Updating state

**Don't modify state directly**

`this.state.comment = 'Hello';`

**State updates may be asynchronous**

```js
// WRONG. Both state and increment might be updated asynchronously and it can lead to a fail, because react may batch 2 updates
this.setState({ counter: this.state.counter + this.props.increment });

// CORRECT
this.setState((state, props) => ({
  // previous state + current props
  counter: state.counter + props.increment
}));
```

**setState merges states**

```js
constructor(props) {
    super(props);
    this.state = {
        posts: [],
        comments: []
    };
}

// Doesn't affect posts
this.setState({
    comments: response.comments
});
```

## Events

**How to prevent default behavior of handler?**

```js
function ActionLink() {
  function handleClick(e) {
    e.preventDefault();
    console.log('The link was clicked.');
  }

  return (
    <a href="#" onClick={handleClick}>
      Click me
    </a>
  );
}
```

## Everything else

**Keys allows to identify which items have changed, are added, or are removed**

Keys used within arrays should be unique among their siblings. However they don’t need to be globally unique

**Controlled vs Uncontrolled components**

Controlled gets state from react. Uncontrolled stores own state internally

```js
// Controlled:
<input type="text" value={value} onChange={handleChange} />

// Uncontrolled:
<input type="text" defaultValue="foo" ref={inputRef} />
// Use `inputRef.current.value` to read the current value of <input>
```

**Performance optimization**

1. Use gzip to transfer data
1. Use `webp` format for image
1. Virtualization of long lists
1. Use `PureComponents`. It does shallow check of props and state. Pure component like a pure function returns the same output for same input
