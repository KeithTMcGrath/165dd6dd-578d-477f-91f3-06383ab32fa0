# Longest Sequence Service

## Features
- Extracts numbers from a string where each number is separated by a single whitespace.
- Identifies the longest sequence of increasing numbers.
- Returns the longest sequence as a string.
- If more than 1 sequence exists with the longest length, output the earliest one

## Installation
There are no external dependencies for this project.

## Usage
Running the console application will prompt the user to enter a string value. The underlying service will process this input, returning the longest sequence as a string. 

The application is opinionated, so if an invalid input is entered an exception is thrown.

## Assumptions
- The input can come from an end user and hence may not conform to the standards specified in the spec.
- A formatting function has been added, with a view to extending this as the need arises (for now this just removes duplicate whitespace).
- An exception will be thrown if invalid input is entered and has not been fixed in the formatting function.
- The logic has been encapsulated as a service as its functionality can be extended and this also allows the service to be inserted via depenency injection if required down the line.

## Test Coverage
The test coverage report can be found in Tests\LongestSequenceServiceTests\CodeCoverageReport.html.