CREATE SCHEMA IF NOT EXISTS online_testing;

CREATE TABLE IF NOT EXISTS online_testing.question
(
    _id              INT          NOT NULL AUTO_INCREMENT,
    _testId          INT          NOT NULL,
    _type            INT          NOT NULL,
    _title           VARCHAR(255) NOT NULL,
    _correctResponse VARCHAR(255) NOT NULL,
    _secondOption    VARCHAR(255),
    _thirdOption     VARCHAR(255),
    _fourthOption    VARCHAR(255),
    PRIMARY KEY (_id),
    CONSTRAINT check_not_null_options_for_choiceOfAnswer_question
        CHECK ((question._type != 0) OR (_secondOption IS NOT NULL AND _thirdOption IS NOT NULL AND _fourthOption IS NOT NULL)),
    CONSTRAINT check_null_options_for_freeEntry_question
        CHECK ((question._type != 1) OR (_secondOption IS NULL AND _thirdOption IS NULL AND _fourthOption IS NULL))
);

CREATE TABLE IF NOT EXISTS online_testing.answer
(
    _id         INT     NOT NULL AUTO_INCREMENT,
    _questionId INT     NOT NULL,
    _response     VARCHAR(255),
    _isCorrect  BOOLEAN NOT NULL,
    PRIMARY KEY (_id),
    FOREIGN KEY (_questionId) REFERENCES online_testing.question (_id)
);