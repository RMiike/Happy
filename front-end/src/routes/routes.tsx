import React from "react";
import { BrowserRouter, Switch, Route } from "react-router-dom";

import SignIn from "../pages/SignIn";
import ForgotPass from "../pages/ForgotPass";
import ChangePass from "../pages/ChangePass";
import SignUp from "../pages/SignUp";
import Landing from "../pages/Landing";
import OrphanagesMap from "../pages/OrphanagesMap";
import Orphanage from "../pages/Orphanage";
import CreateOrphanage from "../pages/CreateOrphanage";

const Routes: React.FC = () => {
  return (
    <BrowserRouter>
      <Switch>
        <Route exact path="/" component={Landing} />
        <Route exact path="/signin" component={SignIn} />
        <Route exact path="/signup" component={SignUp} />
        <Route exact path="/forgot-pass" component={ForgotPass} />
        <Route exact path="/change-pass" component={ChangePass} />
        <Route path="/app" component={OrphanagesMap} />
        <Route path="/orphanages/create" component={CreateOrphanage} />
        <Route path="/orphanages/:id" component={Orphanage} />
      </Switch>
    </BrowserRouter>
  );
};

export default Routes;
