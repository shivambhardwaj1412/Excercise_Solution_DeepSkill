CREATE PROCEDURE sp_GetEmployeeCountByDepartment(
    IN p_DepartmentID INT
)
BEGIN
    SELECT
        DepartmentID,
        COUNT(*) AS TotalEmployees
    FROM Employees
    WHERE DepartmentID = p_DepartmentID
    GROUP BY DepartmentID;
END //

DELIMITER ;

CALL sp_GetEmployeeCountByDepartment(1);

CALL sp_GetEmployeeCountByDepartment(3);

SELECT * FROM Employees;
SELECT * FROM Departments;