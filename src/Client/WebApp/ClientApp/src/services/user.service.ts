const apiUrl = "https://localhost:8001/api";

export const userService = {
  login
};

function login(username, password): any {
  const requestOptions = {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ username, password })
  };

  return fetch(`${apiUrl}/users/authenticate`, requestOptions)
    .then(handleResponse);
}

function logout() {
  // remove user from local storage to log user out
  localStorage.removeItem('user');
}

function handleResponse(response) {
  return response.text().then(text => {
    const data = text && JSON.parse(text);
    console.log(response);
    if (!response.ok) {
      if (response.status === 400) {
        // auto logout if 401 response returned from api
        // TODO: Add logout
        // logout();
      }

      const error = (data && data.message) || response.statusText;
      return Promise.reject(error);
    }

    return data;
  });
}
