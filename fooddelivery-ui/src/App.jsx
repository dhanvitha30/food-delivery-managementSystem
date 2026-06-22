import { BrowserRouter, Routes, Route } from "react-router-dom";
import Login from "./Login";
import Register from "./Register";
import Restaurants from "./Restaurants";
import RestaurantDetails from "./RestaurantDetails";
import Dashboard from "./Dashboard";
import AdminDashboard from "./pages/AdminDashboard";
import CustomerDashboard from "./pages/CustomerDashboard.jsx";
import AddRestaurant from "./pages/AddRestaurant";
import EditRestaurant from "./pages/EditRestaurant";
import AdminRestaurants from "./pages/AdminRestaurants";
import EditMenuItem from "./pages/EditMenuItem";
import Cart from "./Cart";
import Order from "./Order";
import Orders from "./pages/Orders";
import AdminMenuItems from "./pages/AdminMenuItems";
import ProtectedRoute from "./ProtectedRoute";
import AddMenuItem from "./pages/AddMenuItem";

function App() {
  return (
    <BrowserRouter>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/login" element={<Login />} />

        <Route path="/register" element={<Register />} />

        <Route
          path="/restaurants"
          element={
            <ProtectedRoute>
              <Restaurants />
            </ProtectedRoute>
          }
        />

        <Route
          path="/restaurants/:id"
          element={
            <ProtectedRoute>
              <RestaurantDetails />
            </ProtectedRoute>
          }
        />

        <Route
          path="/cart"
          element={
            <ProtectedRoute>
              <Cart />
            </ProtectedRoute>
          }
        />
        <Route
          path="/order"
          element={
            <ProtectedRoute>
              <Order />
            </ProtectedRoute>
          }
        />
        <Route
          path="/orders"
          element={<Orders />}
        />
        <Route
          path="/dashboard"
          element={
            <ProtectedRoute>
              <Dashboard />
            </ProtectedRoute>
          }
        />
        <Route
          path="/admin-dashboard"
          element={
            <ProtectedRoute>
              <AdminDashboard />
            </ProtectedRoute>
          }
        />

        <Route
          path="/customer-dashboard"
          element={
            <ProtectedRoute>
              <CustomerDashboard />
            </ProtectedRoute>
          }
        />

        <Route
          path="/add-restaurant"
          element={
            <ProtectedRoute>
              <AddRestaurant />
            </ProtectedRoute>
          }
        />

        <Route
          path="/edit-restaurant/:id"
          element={
            <ProtectedRoute>
              <EditRestaurant />
            </ProtectedRoute>
          }
        />
        <Route
          path="/admin-restaurants"
          element={
            <ProtectedRoute>
              <AdminRestaurants />
            </ProtectedRoute>
          }
        />
        <Route
          path="/restaurant-details/:id"
          element={<RestaurantDetails />}
        />
        <Route
          path="/admin-menuitems"
          element={<AdminMenuItems />}
        />
        <Route
          path="/edit-menu-item/:id"
          element={<EditMenuItem />}
        />
        <Route
          path="/add-menu-item"
          element={<AddMenuItem />}
        />
      </Routes>
      
    </BrowserRouter>
  );
}

export default App;