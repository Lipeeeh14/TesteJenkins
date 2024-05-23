CREATE DATABASE IF NOT EXISTS dbtasks;

USE dbtasks;

CREATE TABLE Task(
    id          BIGINT AUTO_INCREMENT PRIMARY KEY,
    taskName    VARCHAR(100)    NOT NULL,
    dueDate     DATETIME
);