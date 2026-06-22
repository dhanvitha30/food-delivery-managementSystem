import { useEffect, useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";

function AdminRestaurants() {
  const [restaurants, setRestaurants] = useState([]);
  const navigate = useNavigate();

  const loadRestaurants = async () => {
    try {
      const token = localStorage.getItem("token");

      const response = await axios.get(
        "http://localhost:5134/api/Restaurants",
        {
          headers: {
            Authorization: `Bearer ${token}`
          }
        }
      );

      setRestaurants(response.data);
    } catch (error) {
      console.log(error);
    }
  };

  useEffect(() => {
    loadRestaurants();
  }, []);

  const deleteRestaurant = async (id) => {
    try {
      const token = localStorage.getItem("token");

      await axios.delete(
        `http://localhost:5134/api/Restaurants/${id}`,
        {
          headers: {
            Authorization: `Bearer ${token}`
          }
        }
      );

      alert("Restaurant Deleted");

      loadRestaurants();
    } catch (error) {
      console.log(error);
    }
  };

  return (
    <div className="container">
      <h1>Admin Restaurants</h1>

      {restaurants.map((restaurant) => (
        <div
          key={restaurant.id}
          className="restaurant-card"
        >
          <h3>{restaurant.name}</h3>

          <p>{restaurant.address}</p>

          <button
            className="btn"
            onClick={() =>
              navigate(
                `/edit-restaurant/${restaurant.id}`
              )
            }
          >
            Update
          </button>

          <button
            className="btn"
            onClick={() =>
              deleteRestaurant(restaurant.id)
            }
          >
            Delete
          </button>
        </div>
      ))}
    </div>
  );
}

export default AdminRestaurants;