import api from "./api";

export const getMenuItems = async () => {
    const response = await api.get("/MenuItems");
    return response.data;
};

export const createMenuItem = async (menuItem) => {
    const response = await api.post("/MenuItems", menuItem);
    return response.data;
};

export const updateMenuItem = async (id, menuItem) => {
    const response = await api.put(`/MenuItems/${id}`, menuItem);
    return response.data;
};

export const deleteMenuItem = async (id) => {
    const response = await api.delete(`/MenuItems/${id}`);
    return response.data;
};