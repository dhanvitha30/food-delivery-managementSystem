import { useState, useEffect } from "react";
import { useParams, useNavigate } from "react-router-dom";
import axios from "axios";

function EditRestaurant() {
  const { id } = useParams();
  const navigate = useNavigate();

  const [restaurant, setRestaurant] = useState({
    name: "",
    address: "",
    phone: "",
  });

  useEffect(() => {
    fetchRestaurant();
  }, []);

  const fetchRestaurant = async () => {
    try {
      const token = localStorage.getItem("token");

      const response = await axios.get(
        "http://localhost:5134/api/Restaurants",
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );

      const selectedRestaurant =
        response.data.find(
          (r) => r.id === parseInt(id)
        );

      if (selectedRestaurant) {
        setRestaurant(selectedRestaurant);
      }
    } catch (error) {
      console.log(error);
      alert("Failed to load restaurant");
    }
  };

  const handleChange = (e) => {
    setRestaurant({
      ...restaurant,
      [e.target.name]: e.target.value,
    });
  };

  const handleSubmit = async (e) => {
    e.preventDefault();

    try {
      const token = localStorage.getItem("token");

      await axios.put(
        `http://localhost:5134/api/Restaurants/${id}`,
        {
          name: restaurant.name,
          address: restaurant.address,
          phone: restaurant.phone,
        },
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );

      alert("Restaurant Updated Successfully");

      navigate("/restaurants");
    } catch (error) {
      console.log(error);
      alert("Update Failed");
    }
  };

  return (
    <div className="container">
      <h1>Edit Restaurant</h1>

      <form onSubmit={handleSubmit}>
        <input
          type="text"
          name="name"
          placeholder="Restaurant Name"
          value={restaurant.name}
          onChange={handleChange}
          className="input"
        />

        <br />
        <br />

        <input
          type="text"
          name="address"
          placeholder="Address"
          value={restaurant.address}
          onChange={handleChange}
          className="input"
        />

        <br />
        <br />

        <input
          type="text"
          name="phone"
          placeholder="Phone"
          value={restaurant.phone}
          onChange={handleChange}
          className="input"
        />

        <br />
        <br />

        <button
          type="submit"
          className="btn"
        >
          Update Restaurant
        </button>
      </form>
    </div>
  );
}

export default EditRestaurant;