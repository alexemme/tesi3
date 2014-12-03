import os, sys
import optparse
import subprocess
import random

# we need to import python modules from the $SUMO_HOME/tools directory
try:
    sys.path.append(os.path.join(os.path.dirname(__file__), '..', '..', '..', '..', "tools")) # tutorial in tests
    sys.path.append(os.path.join(os.environ.get("SUMO_HOME", os.path.join(os.path.dirname(__file__), "..", "..", "..")), "tools")) # tutorial in docs
    from sumolib import checkBinary
    import traci
except ImportError:
    print("prova")
    sys.exit("please declare environment variable 'SUMO_HOME' as the root directory of your sumo installation (it should contain folders 'bin', 'tools' and 'docs')")


# the port used for communicating with your sumo instance
PORT = 8874


#MAIN
arg= sys.argv[1] #prendo il primo argomento passato 
if arg == 'gui' :
    sumoBinary = checkBinary('sumo-gui')
else:
    sumoBinary = checkBinary('sumo')

nomefile = sys.argv[2]

def run():
    #"""execute the TraCI control loop"""
    traci.init(PORT)
    step = 0
    while traci.simulation.getMinExpectedNumber() > 0:
        traci.simulationStep()
        #        traci.trafficlights.setRedYellowGreenState("0", PROGRAM[programPointer])
        step += 1
    traci.close()
    sys.stdout.flush()



sumoProcess = subprocess.Popen([sumoBinary, "-c", nomefile, "--tripinfo-output", "tripinfo.xml", "--remote-port", str(PORT)], stdout=sys.stdout, stderr=sys.stderr)
#print('Args: ' + nomefile)
#raw_input("Press enter to continue")
run()
sumoProcess.wait()