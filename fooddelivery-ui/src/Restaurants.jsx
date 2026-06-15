import { useState } from "react";

function Restaurants() {
  const restaurants = [
    { name: "Paradise Biryani", location: "Hyderabad" },
    { name: "KFC", location: "Madhapur" },
    { name: "Domino's Pizza", location: "Hitech City" },
    { name: "Burger King", location: "Gachibowli" },
    { name: "Mehfil", location: "Kukatpally" },
    { name: "Pizza Hut", location: "Miyapur" }
  ];

  const [search, setSearch] = useState("");
  const [currentPage, setCurrentPage] = useState(1);

  const restaurantsPerPage = 3;

  const filteredRestaurants = restaurants.filter((restaurant) =>
    restaurant.name.toLowerCase().includes(search.toLowerCase())
  );

  const lastIndex = currentPage * restaurantsPerPage;
  const firstIndex = lastIndex - restaurantsPerPage;

  const currentRestaurants =
    filteredRestaurants.slice(firstIndex, lastIndex);

  const totalPages = Math.ceil(
    filteredRestaurants.length / restaurantsPerPage
  );

  return (
    <div className="container">
      <h1>Restaurants</h1>

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
        {currentRestaurants.map((restaurant, index) => (
          <div className="restaurant-card" key={index}>
            <h3>{restaurant.name}</h3>
            <p>{restaurant.location}</p>
          </div>
        ))}
      </div>

      <div className="pagination">
        <button
          className="btn"
          disabled={currentPage === 1}
          onClick={() => setCurrentPage(currentPage - 1)}
        >
          Previous
        </button>

        <span> Page {currentPage} of {totalPages} </span>

        <button
          className="btn"
          disabled={currentPage === totalPages}
          onClick={() => setCurrentPage(currentPage + 1)}
        >
          Next
        </button>
      </div>
    </div>
  );
}

export default Restaurants;