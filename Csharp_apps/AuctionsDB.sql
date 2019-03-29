SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema mydb
-- -----------------------------------------------------
-- -----------------------------------------------------
-- Schema auctionsdb
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema auctionsdb
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `auctionsdb` DEFAULT CHARACTER SET utf8 ;
USE `auctionsdb` ;

-- -----------------------------------------------------
-- Table `auctionsdb`.`users`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `auctionsdb`.`users` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `username` VARCHAR(45) NOT NULL,
  `password` VARCHAR(255) NOT NULL,
  `first_name` VARCHAR(45) NOT NULL,
  `last_name` VARCHAR(45) NOT NULL,
  `available_funds` INT(11) NOT NULL,
  `created_at` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC))
ENGINE = InnoDB
AUTO_INCREMENT = 31
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `auctionsdb`.`auctions`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `auctionsdb`.`auctions` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `creatorid` INT(11) NOT NULL,
  `product` VARCHAR(45) NOT NULL,
  `description` MEDIUMTEXT NOT NULL,
  `opening_bid` INT(11) NOT NULL,
  `sold_for` INT(11) NOT NULL,
  `ending_at` DATETIME NOT NULL,
  `created_at` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC),
  INDEX `fk_Auctions_Users_idx` (`creatorid` ASC),
  CONSTRAINT `fk_Auctions_Users`
    FOREIGN KEY (`creatorid`)
    REFERENCES `auctionsdb`.`users` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 30
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `auctionsdb`.`bids`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `auctionsdb`.`bids` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `userid` INT(11) NOT NULL,
  `auctionid` INT(11) NOT NULL,
  `amount` INT(11) NOT NULL,
  `created_at` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE INDEX `id_UNIQUE` (`id` ASC),
  INDEX `fk_Bids_Users1_idx` (`userid` ASC),
  INDEX `fk_Bids_Auctions1_idx` (`auctionid` ASC),
  CONSTRAINT `fk_Bids_Auctions1`
    FOREIGN KEY (`auctionid`)
    REFERENCES `auctionsdb`.`auctions` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Bids_Users1`
    FOREIGN KEY (`userid`)
    REFERENCES `auctionsdb`.`users` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 21
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
