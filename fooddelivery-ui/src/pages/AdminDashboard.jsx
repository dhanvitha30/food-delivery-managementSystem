
import { useNavigate } from "react-router-dom";

function AdminDashboard() {
  const navigate = useNavigate();

  return (
    <div className="container">

function AdminDashboard() {
  return (
    <div>

      <h1>Admin Dashboard</h1>

      <h2>Restaurant Management</h2>


      <button
        className="btn"
        onClick={() => navigate("/add-restaurant")}
      >
        Add Restaurant
      </button>

      <br /><br />

      <button
        className="btn"
        onClick={() => navigate("/admin-restaurants")}
      >
        View / Update / Delete Restaurants
      </button>

      <br /><br /><br />

      <h2>Menu Management</h2>

      <button
        className="btn"
        onClick={() => navigate("/add-menu-item")}
      >
        Add Menu Item
      </button>

      <br /><br />

      <button
        className="btn"
        onClick={() => navigate("/admin-menuitems")}
      >
        View / Update / Delete Menu Items
      </button>

      <button>Add Restaurant</button>
      <button>Update Restaurant</button>
      <button>Delete Restaurant</button>

    </div>
  );
}

export default AdminDashboard;