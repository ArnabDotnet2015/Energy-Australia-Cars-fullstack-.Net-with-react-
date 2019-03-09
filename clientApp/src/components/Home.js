import React from 'react';

const Home = props => (
  <div>
    <h1>Hello, world!</h1>
    <p>Welcome to your new single-page application, built with:</p>
    <ul>
      <li><a href='https://get.asp.net/'>ASP.NET Core</a> and <a href='https://msdn.microsoft.com/en-us/library/67ef8sbd.aspx'>C#</a> for cross-platform server-side code</li>
      <li><a href='https://facebook.github.io/react/'>React</a> and <a href='https://redux.js.org/'>Redux</a> for client-side code</li>
      <li><a href='http://getbootstrap.com/'>Bootstrap</a> for layout and styling</li>
    </ul>
    <p>To help you get started, we've also set up:</p>
    <ul>
      <li><strong>Client-side navigation</strong>. For example, click <em>Cars</em></li>
      <li><strong>Development server integration</strong>. In development mode, the development server from <code>create-react-app</code> runs in the background automatically, so your client-side resources are dynamically built on demand and the page refreshes when you modify any file.</li>
    </ul>
  </div>
);

export default (Home);
