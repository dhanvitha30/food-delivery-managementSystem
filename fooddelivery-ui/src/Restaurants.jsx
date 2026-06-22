import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";

function Restaurants() {
  const navigate = useNavigate();

  const [restaurants, setRestaurants] = useState([]);
  const [search, setSearch] = useState("");
  const [currentPage, setCurrentPage] = useState(1);

  useEffect(() => {
    fetchRestaurants();
  }, []);

  const fetchRestaurants = async () => {
  try {
    const token = localStorage.getItem("token");
    

    console.log("TOKEN:", token);

    const response = await axios.get(
      "http://localhost:5134/api/Restaurants",
      {
        headers: {
          Authorization: `Bearer ${token}`,
        },
      }
    );

    console.log("FULL RESPONSE");
    console.log(response.data);

    setRestaurants(response.data);
  } catch (error) {
    console.log("ERROR:", error);

    if (error.response) {
      console.log("STATUS:", error.response.status);
      console.log("DATA:", error.response.data);
    }

    alert("Failed to load restaurants");
  }
};

  const deleteRestaurant = async (id) => {
    try {
      const token = localStorage.getItem("token");
      console.log ("token");

      await axios.delete(
        `http://localhost:5134/api/Restaurants/${id}`,
        {
          headers: {
            Authorization: `Bearer ${token}`,
          },
        }
      );

      alert("Restaurant Deleted Successfully");

      setRestaurants(
        restaurants.filter(
          (restaurant) => restaurant.id !== id
        )
      );
    } catch (error) {
      console.log(error);
      alert("Delete Failed");
    }
  };

  const restaurantsPerPage = 3;

  const filteredRestaurants = restaurants.filter(
    (restaurant) =>
      restaurant.name
        .toLowerCase()
        .includes(search.toLowerCase())
  );

  const lastIndex = currentPage * restaurantsPerPage;
  const firstIndex = lastIndex - restaurantsPerPage;

  const currentRestaurants =
    filteredRestaurants.slice(
      firstIndex,
      lastIndex
    );

  const totalPages = Math.ceil(
    filteredRestaurants.length /
      restaurantsPerPage
  );

  return (
    <div className="container">
      <h1>Restaurants</h1>

      <button
        className="btn"
        onClick={() => navigate("/dashboard")}
      >
        Dashboard
      </button>

      <br />
      <br />

      <input
        type="text"
        placeholder="Search Restaurant"
        className="input"
        value={search}
        onChange={(e) => {
          setSearch(e.target.value);
          setCurrentPage(1);
        }}
      />

      <div className="restaurant-grid">
        {currentRestaurants.map((restaurant) => (
          <div
            key={restaurant.id}
            className="restaurant-card"
            style={{ cursor: "pointer" }}
            onClick={() =>
              navigate(
                `/restaurant-details/${restaurant.id}`
              )
            }
          >
            <h3>{restaurant.name}</h3>

            <p>
              <strong>Address:</strong>{" "}
              {restaurant.address}
            </p>

            <p>
              <strong>Phone:</strong>{" "}
              {restaurant.phone}
            </p>
          </div>
        ))}
      </div>

      <div className="pagination">
        <button
          className="btn"
          disabled={currentPage === 1}
          onClick={() =>
            setCurrentPage(currentPage - 1)
          }
        >
          Previous
        </button>

        <span>
          Page {currentPage} of {totalPages}
        </span>

        <button
          className="btn"
          disabled={
            currentPage === totalPages
          }
          onClick={() =>
            setCurrentPage(currentPage + 1)
          }
        >
          Next
        </button>
        <button
          className="btn"
          onClick={() => navigate("/cart")}
        >
          View Cart
        </button>

        &nbsp;

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

export default Restaurants;