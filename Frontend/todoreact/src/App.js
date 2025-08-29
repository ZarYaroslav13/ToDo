import './App.css';
import { Router } from "./components/router/router"
import { AuthProvider } from "./components/authprovider/authprovider"

function App() {
  return (
    <div className="App">
        <AuthProvider>
            <Router/>
        </AuthProvider>
    </div>
  );
}

export default App;
