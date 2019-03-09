import React from "react";
import renderer from "react-test-renderer";
import { BrowserRouter } from "react-router-dom";
import App from "./App";

test('spanshot test ', () => {
  const component = renderer.create(
  <BrowserRouter>
    <App />
  </BrowserRouter>)
  const tree = component.toJSON();
  expect(tree).toMatchSnapshot();
})
