import { useState } from "react";
import { Link, useNavigate } from "react-router-dom";
import axios from "axios";
import "./App.css";

function Register() {
  const navigate = useNavigate();

  const [name, setName] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [role, setRole] = useState("Customer");

  const handleRegister = async () => {
    if (!name || !email || !password || !role) {
      alert("All fields are required");
      return;
    }

    try {
      const response = await axios.post(
        "http://localhost:5134/api/Auth/register",
        {
          name,
          email,
          password,
          role
        }
      );

      alert(response.data.message);

      navigate("/login");
    } catch (error) {
      console.log(error);

      alert(
        error.response?.data ||
        "Registration failed"
      );
    }
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

      <br /><br />

      <input
        type="email"
        placeholder="Email"
        className="input"
        value={email}
        onChange={(e) => setEmail(e.target.value)}
      />

      <br /><br />

      <input
        type="password"
        placeholder="Password"
        className="input"
        value={password}
        onChange={(e) => setPassword(e.target.value)}
      />

      <br /><br />

      <select
        className="input"
        value={role}
        onChange={(e) => setRole(e.target.value)}
      >
        <option value="Customer">Customer</option>
        <option value="Admin">Admin</option>
      </select>

      <br /><br />

      <button
        className="btn"
        onClick={handleRegister}
      >
        Register
      </button>

      <p>
        Already have an account?
        <Link to="/login"> Login</Link>
      </p>
    </div>
  );
}

export default Register;