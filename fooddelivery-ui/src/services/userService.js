import api from "./api";

export const getUsers = async () => {
    const response = await api.get("/Users");
    return response.data;
};

export const deleteUser = async (id) => {
    const response = await api.delete(`/Users/${id}`);
    return response.data;
};