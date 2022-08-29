#!/bin/bash
echo "Generating code from model"
java -jar tools/raisaGen/app9.jar tools/raisagen/model/model.xml ./
read -n1 -r -p "Press any key to continue..." key