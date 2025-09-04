import './App.css';
import {Router} from "./components/router/router"
import { AuthProvider } from "./components/authprovider/authProvider"
import {SnackbarProvider} from "./components/snackbarProvider/snackbarProvider";

function App() {
  return (
    <div className="App">
        <AuthProvider>
            <SnackbarProvider>
                <Router/>
            </SnackbarProvider>
        </AuthProvider>
    </div>
  );
}

export default App;
