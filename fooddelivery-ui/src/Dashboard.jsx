import { Link } from "react-router-dom";

function Dashboard() {
  const cart =
    JSON.parse(localStorage.getItem("cart")) || [];

  return (
    <div className="container">
      <h1>User Dashboard</h1>

      <div className="restaurant-card">
        <h3>Total Cart Items</h3>
        <p>{cart.length}</p>
      </div>

      <div className="restaurant-card">
        <h3>Quick Links</h3>

        <p>
          <Link to="/restaurants">
            Restaurants
          </Link>
        </p>

        <p>
          <Link to="/cart">
            Cart
          </Link>
        </p>
      </div>
    </div>
  );
}

export default Dashboard;