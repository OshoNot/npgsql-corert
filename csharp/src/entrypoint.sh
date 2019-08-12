#!/bin/bash

while ! pg_isready -h database  > /dev/null 2> /dev/null; do
    echo "Connecting to database Failed"
    sleep 1
  done

# run sample
./outside/CSample

echo "Test Finished"
sleep infinity
