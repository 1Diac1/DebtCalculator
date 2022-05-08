export default function authHeader() {
  const user = JSON.parse(Cookies.get('user'));

  if (user && user.token) {
    // user.accessToken
    return {"Authorization": 'Bearer' + user.token};
  } else {
    return {};
  }
}