import api from "./api";

export const register = async (userData) => {
  const response = await api.post(
    "/Auth/register",
    userData
  );

  return response.data;
};

export const login = async (loginData) => {
  const response = await api.post(
    "/Auth/login",
    loginData
  );

  return response.data;
};