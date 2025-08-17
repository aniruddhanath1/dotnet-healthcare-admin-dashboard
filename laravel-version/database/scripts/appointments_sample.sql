-- MySQL script to create appointments table and insert 10 sample rows
CREATE TABLE IF NOT EXISTS `appointments` (
  `id` BIGINT UNSIGNED NOT NULL AUTO_INCREMENT,
  `patient_id` BIGINT UNSIGNED NOT NULL,
  `doctor_id` BIGINT UNSIGNED NOT NULL,
  `scheduled_at` TIMESTAMP NOT NULL,
  `status` VARCHAR(255) NOT NULL,
  `notes` TEXT NULL,
  `created_at` TIMESTAMP NULL DEFAULT NULL,
  `updated_at` TIMESTAMP NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

INSERT INTO `appointments` (`patient_id`, `doctor_id`, `scheduled_at`, `status`, `notes`, `created_at`, `updated_at`) VALUES
(1, 1, '2025-08-18 09:00:00', 'scheduled', 'First appointment', NOW(), NOW()),
(2, 2, '2025-08-18 10:00:00', 'scheduled', 'Second appointment', NOW(), NOW()),
(3, 3, '2025-08-18 11:00:00', 'completed', 'Third appointment', NOW(), NOW()),
(4, 4, '2025-08-18 12:00:00', 'cancelled', 'Fourth appointment', NOW(), NOW()),
(5, 5, '2025-08-18 13:00:00', 'scheduled', 'Fifth appointment', NOW(), NOW()),
(6, 1, '2025-08-18 14:00:00', 'scheduled', 'Sixth appointment', NOW(), NOW()),
(7, 2, '2025-08-18 15:00:00', 'completed', 'Seventh appointment', NOW(), NOW()),
(8, 3, '2025-08-18 16:00:00', 'scheduled', 'Eighth appointment', NOW(), NOW()),
(9, 4, '2025-08-18 17:00:00', 'cancelled', 'Ninth appointment', NOW(), NOW()),
(10, 5, '2025-08-18 18:00:00', 'scheduled', 'Tenth appointment', NOW(), NOW());
