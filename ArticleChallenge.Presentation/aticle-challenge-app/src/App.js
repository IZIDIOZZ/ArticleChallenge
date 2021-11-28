import {Routes, Route, Switch, Redirect } from 'react-router-dom';
import NavBar from './components/common/navBar';
import Articles from './components/articles';
import NotFound from './components/common/notFound';
import Article from './components/article';
import 'bootstrap/dist/css/bootstrap.css';
import 'font-awesome/css/font-awesome.css';
import { storeUserId } from './services/localStorageService';
import { React, Fragment } from 'react';

function App() {
  storeUserId();
  return (
    <Fragment>
        <NavBar/>
        <main className="container h-100">
        <div className='content'> 
            <Switch>
            <Route path="/articles/:id" component={(props)=><Article {...props}/>} />
            <Route path="/"  component={Articles} />
            <Route path="/not-found" component={NotFound} />
            {/* <Redirect from="/" exact to="/"/> */}
            <Redirect to="/not-found" />
            </Switch>
        </div>
    </main>
    </Fragment>
  );
}

export default App;
