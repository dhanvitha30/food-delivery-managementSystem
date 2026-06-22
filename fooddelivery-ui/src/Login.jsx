import { useState } from "react";

import { Link, useNavigate } from "react-router-dom";

import { Link } from "react-router-dom";

import axios from "axios";
import "./App.css";

function Login() {
  const navigate = useNavigate();

  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleLogin = async () => {
    try {
      const response = await axios.post(
        "http://localhost:5134/api/Auth/login",
        {
          email,

          password,
        }
      );
      console.log("token");

          password
        }
      );


      localStorage.setItem(
        "token",
        response.data.token
      );

      localStorage.setItem(
        "userId",
        response.data.userId
      );

      localStorage.setItem(
        "role",
        response.data.role
      );
      console.log(response.data);

      if (response.data.role === "Admin") {
        navigate("/admin-dashboard");
      } else {
        navigate("/customer-dashboard");
      }
    } catch (error) {
      console.log(error);
      alert("Invalid Email or Password");


      window.location.href = "/restaurants";
    }
    catch (error) {
      alert("Invalid email or password");

    }
  };

  return (
    <div className="container">
      <h1>Login Page</h1>

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
        onClick={handleLogin}
      >
        Login
      </button>

      <p>
        Don't have an account?
        <Link to="/register"> Register</Link>
      </p>
    </div>
  );
}

export default Login;