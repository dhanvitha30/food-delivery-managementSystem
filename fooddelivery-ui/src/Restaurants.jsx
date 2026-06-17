import { useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";

function Restaurants() {
  const navigate = useNavigate();

  const [restaurants, setRestaurants] = useState([]);
  const [search, setSearch] = useState("");
  const [currentPage, setCurrentPage] = useState(1);

  useEffect(() => {
    axios
      .get("https://jsonplaceholder.typicode.com/users")
      .then((response) => {
        const data = response.data.map((user) => ({
          id: user.id,
          name: user.name,
          location: user.address.city,
        }));

        setRestaurants(data);
      })
      .catch((error) => {
        console.log(error);
      });
  }, []);

  const restaurantsPerPage = 3;

  const filteredRestaurants = restaurants.filter((restaurant) =>
    restaurant.name.toLowerCase().includes(search.toLowerCase())
  );

  const lastIndex = currentPage * restaurantsPerPage;
  const firstIndex = lastIndex - restaurantsPerPage;

  const currentRestaurants = filteredRestaurants.slice(
    firstIndex,
    lastIndex
  );

  const totalPages = Math.ceil(
    filteredRestaurants.length / restaurantsPerPage
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
            onClick={() =>
              navigate(`/restaurants/${restaurant.id}`)
            }
            style={{ cursor: "pointer" }}
          >
            <h3>{restaurant.name}</h3>
            <p>{restaurant.location}</p>
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
          disabled={currentPage === totalPages}
          onClick={() =>
            setCurrentPage(currentPage + 1)
          }
        >
          Next
        </button>
      </div>
    </div>
  );
}

export default Restaurants;