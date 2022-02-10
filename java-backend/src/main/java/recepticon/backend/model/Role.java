package recepticon.backend.model;

public enum Role {

    RECEPTIONIST,
    ADMIN;

    public String getDisplayName() {
        return name();
    }

}
