import React, { useState } from "react";

interface ExampleProps {
  extraText?: string;
}
// const Example = (extraText = "test": string ) => {
function Example({ extraText }: ExampleProps): JSX.Element {
  const [change, setChange] = useState(true);
  return (
    <div>
      <p>{extraText}</p>
      <button onClick={() => setChange(!change)}>Click Here!</button>
      {change ? <h1>Welcome to Let’s React</h1> : <h1>Learn about the concepts of Reactjs</h1>}
    </div>
  );
}

export default Example;
