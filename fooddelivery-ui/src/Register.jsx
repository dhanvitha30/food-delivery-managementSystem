import { useState } from "react";
import { Link } from "react-router-dom";
import "./App.css";

function Register() {
  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleRegister = () => {
    if (!name || !email || !password) {
      alert("All fields are required");
      return;
    }

    alert("Registration Successful");
  };

  return (
    <div className="container">
      <h1>Register Page</h1>

      <input
        type="text"
        placeholder="Name"
        className="input"
        value={name}
        onChange={(e) => setName(e.target.value)}
      />

      <br />
      <br />

      <input
        type="email"
        placeholder="Email"
        className="input"
        value={email}
        onChange={(e) => setEmail(e.target.value)}
      />

      <br />
      <br />

      <input
        type="password"
        placeholder="Password"
        className="input"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
      />

      <br />
      <br />

      <button
        className="btn"
        onClick={handleRegister}
      >
        Register
      </button>

      <p>
        Already have an account?
        <Link to="/"> Login</Link>
      </p>
    </div>
  );
}

export default Register;