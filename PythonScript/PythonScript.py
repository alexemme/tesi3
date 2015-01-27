import os, sys
import optparse
import subprocess
import random
import csv

# we need to import python modules from the $SUMO_HOME/tools directory
try:
    sys.path.append(os.path.join(os.path.dirname(__file__), '..', '..', '..', '..', "tools")) # tutorial in tests
    sys.path.append(os.path.join(os.environ.get("SUMO_HOME", os.path.join(os.path.dirname(__file__), "..", "..", "..")), "tools")) # tutorial in docs
    from sumolib import checkBinary
    import traci
except ImportError:
    print("errore di importazione librerie python")
    sys.exit("please declare environment variable 'SUMO_HOME' as the root directory of your sumo installation (it should contain folders 'bin', 'tools' and 'docs')")
# the port used for communicating with your sumo instance
PORT = 8874

#MAIN
percSumo = sys.argv[1] #passo il percorso di sumo
nomefilePerc = sys.argv[2]
nomefile = sys.argv[3]
nomeoutput = sys.argv[4]
campionamenti = sys.argv[5]


def run():
    #"""execute the TraCI control loop"""
    traci.init(PORT)
    try:
        numRou = traci.route.getIDCount()
        step = 0 
        listaRou = traci.route.getIDList()
        numLanesIngresso = 0 
        for i in range(numRou-1):
            listaLanes = traci.route.getEdges(listaRou[i])
            flag_found = 0
            for j in range(numLanesIngresso):
                if listaLanes[0] == listaLanesIngresso[j]:
                    flag_found = 1
            if numLanesIngresso == 0 :
                numLanesIngresso = 1 
                listaLanesIngresso = [listaLanes[0]]
                flag_found = 1
            if flag_found == 0:
                listaLanesIngresso.append  (listaLanes[0])
                numLanesIngresso = numLanesIngresso + 1
            #ho le linee in ingresso su listaLanesIngresso
        with open(nomefilePerc + "/" + nomeoutput + ".OUTcampionamenti.csv", 'wb') as csvfile:
            a = csv.writer(csvfile , delimiter=";")
            data = ['tempo(s)']
            data.append ('VeicTotali')
            for i in range (numLanesIngresso):
                data.append('"' + listaLanesIngresso[i] + '"')
            a.writerow(data)
            contatore = 0
            contatore = int (campionamenti)
            while traci.simulation.getMinExpectedNumber() > 0: # finche' ci sono veicoli nella rete...
                traci.simulationStep() # procedi allo step successivo        
                if contatore == 0:
                    data = []
                    data.append(step)
                    data.append(traci.simulation.getMinExpectedNumber())
                    for i in range(numLanesIngresso):
                       data.append ( traci.lane.getLastStepHaltingNumber(listaLanesIngresso[i]+ "_0"))
                    print step
                    a.writerow(data)
                    contatore = int(campionamenti) 
                contatore = contatore - 1
                step += 1
        sys.stdout.flush()
    except :
        print "Errore insapettato:", sys.exc_info()[0]
        raw_input("Premi enter per continuare") 
    traci.close()

#print(percSumo)
#raw_input("Press enter to continue")
sumoProcess = subprocess.Popen([percSumo, "-c", nomefilePerc + "/" + nomefile, "--tripinfo-output", nomefilePerc + "/" + "tripinfo.xml", "--remote-port", str(PORT)], stdout=sys.stdout, stderr=sys.stderr)
run()
sumoProcess.wait()