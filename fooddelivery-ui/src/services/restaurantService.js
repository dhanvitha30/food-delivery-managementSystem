import api from "./api";

export const getRestaurants = async () => {
  const response = await api.get("/Restaurants");
  return response.data;
};