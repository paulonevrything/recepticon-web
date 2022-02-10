package recepticon.backend.model.response;

import recepticon.backend.dto.UserDTO;

public class AuthenticateResponseModel extends UserDTO {

    private String token;

    public AuthenticateResponseModel(String token) {
        this.token = token;
    }

    public String getToken() {
        return token;
    }

    public void setToken(String token) {
        this.token = token;
    }
}
