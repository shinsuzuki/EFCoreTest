BEGIN TRANSACTION;

ALTER TABLE "Blogs" ADD "Name" TEXT NOT NULL DEFAULT '';

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240622073341_addName', '8.0.6');

COMMIT;

BEGIN TRANSACTION;

ALTER TABLE "Posts" ADD "Name" TEXT NOT NULL DEFAULT '';

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20240622073439_addPostName', '8.0.6');

COMMIT;

