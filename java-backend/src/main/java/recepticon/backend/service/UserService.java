package recepticon.backend.service;

import recepticon.backend.dto.UserDTO;
import recepticon.backend.model.User;

import java.util.List;

public interface UserService {

    User save(UserDTO user);
    List<User> findAll();
    User findOne(String username);
}
