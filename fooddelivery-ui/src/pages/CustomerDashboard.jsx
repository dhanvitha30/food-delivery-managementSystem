import { useNavigate } from "react-router-dom";

function CustomerDashboard() {
  const navigate = useNavigate();

  return (
    <div className="container">
      <h1>Customer Dashboard</h1>

      <div style={{ marginTop: "20px" }}>
        <button
          className="btn"
          onClick={() => navigate("/restaurants")}
        >
          Browse Restaurants
        </button>

        <br /><br />

        <button
          className="btn"
          onClick={() => navigate("/cart")}
        >
          View Cart
        </button>

        <br /><br />

        <button
          className="btn"
          onClick={() => navigate("/orders")}
        >
          Previous Orders
        </button>
      </div>
    </div>
  );
}

export default CustomerDashboard;