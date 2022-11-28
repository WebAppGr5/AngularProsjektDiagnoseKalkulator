
using Microsoft.EntityFrameworkCore;
using obligDiagnoseVerktøyy.Model.entities;
using System.Xml;
using DiagnoseKalkulatorAngular.Data;
using symptkalk.model;
using symptkalk.Model;
using static System.Reflection.Metadata.BlobBuilder;

namespace DiagnoseKalkulatorAngular.data
{

    public static class ApplicationBuilderExtensions
    {
        public static async Task<IApplicationBuilder> PrepareDatabase(this IApplicationBuilder app)
        {
            using var scopedServices = app.ApplicationServices.CreateScope();

            var serviceProvider = scopedServices.ServiceProvider;
            var db = serviceProvider.GetRequiredService<ApplicationDbContext>();

            db.symptom.ToList().ForEach((x) => db.Remove(x));
            db.diagnose.ToList().ForEach((x) => db.Remove(x));
            db.diagnoseGruppe.ToList().ForEach((x) => db.Remove(x));
            db.symptomSymptomBilde.ToList().ForEach((x) => db.Remove(x));
            db.symptomGruppe.ToList().ForEach((x) => db.Remove(x));
            db.symptomBilde.ToList().ForEach((x) => db.Remove(x));
            db.brukerInfo.ToList().ForEach((x) => db.Remove(x));
            db.brukerLogin.ToList().ForEach((x) => db.Remove(x));

            db.SaveChanges();

            db.Database.OpenConnection();

            List<Diagnose> diagnoser;
            List<DiagnoseGruppe> diagnoseGrupper;
            List<Symptom> symptomer;
            List<SymptomGruppe> symptomGrupper;
            List<SymptomBilde> symptomBilder;
            List<SymptomSymptomBilde> symptomSymptomBilder;
            List<BrukerInfo> brukerInfo;
            List<BrukerLogIn> brukerLogIn;

            

            brukerInfo = new List<BrukerInfo>
            {
                new BrukerInfo
                {
                    etternavn = "per",
                    Fornavn = "jola",
                    ID = 1
                },
                new BrukerInfo
                {
                    etternavn = "ter",
                    Fornavn = "saga",
                    ID = 2
                }
            };
            brukerInfo.ForEach((x) => db.brukerInfo.Add(x));
            db.SaveChanges();


            brukerLogIn = new List<BrukerLogIn>
            {
                new BrukerLogIn
                {
                    brukernavn = "tora",
                    ID=1,
                    passord="123456"
                },
                new BrukerLogIn
                {
                    brukernavn = "tarfo",
                    ID=2,
                    passord="test1234"
                }
            };
            brukerLogIn.ForEach((x) => db.brukerLogin.Add(x));
            db.SaveChanges();

            diagnoseGrupper = new List<DiagnoseGruppe>
            {
                new DiagnoseGruppe
                {
                    diagnoseGruppeId=1,
                    beskrivelse="Hjerte problem",
                    navn="hjerte",
                    dypForklaring = "Kjevemunnenes hjerte ble videreutviklet i de landlevende virveldyrenes stamart. Det var her det andre forkammeret kom til. Et slikt hjerte med to forkamre og én hjertekammer finner man fortsatt hos amfibiene.\r\n\r\nHjertet pumper her blandingsblod, i og med at det ene forkammeret mottar oksygenfattig blod fra kroppen og det andre forkammeret oksygenrikt blod fra lungene.\r\n\r\nDe resterende landlevende virveldyrene har ikke bare to forkamre, men også to hjertekamre. Delingen av hjertekammeret skjedde altså i stamarten til amniondyr, men skilleveggen var ikke fullstendig. Dette medfører at venøst og arterielt blod blandes i hjertet. Samtidig med delingen av hjertekammeret ble hjertekonen delt i tre; en del danner overgangen til lungearterien, en annen til den venstre aortaen og den siste til den høyre aortaen. Denne tilstanden finner man i dag hos broøgler, skilpadder og skjellkrypdyr.\r\n\r\nHjertets skillevegg ble fullstendig lukket to ganger uavhengig av hverandre innenfor amniondyrene. Den ene gangen var i den felles stamarten for krokodiller og fugler; den andre gangen var i pattedyrenes stamart. Dermed ligger i disse gruppene tingene til rette for en fullstendig adskillelse av venøst og arterielt blod. I både fugler og pattedyr har dessuten den ene av aortaene gått tapt. Men mens fugler kun har bevart den høyre aortaen, er det i pattedyrene den venstre aortaen som er bevart."
                },
                new DiagnoseGruppe
                {
                    diagnoseGruppeId=2,
                    beskrivelse="Lunge problem",
                    navn="lunge",
                    dypForklaring = "Lungene (pulmonum) er det sentrale organet i åndedrettssystemet. De to lungene ligger i brysthulen, på hver sin side av brystskilleveggen (mediastinum). De har form som tresidige pyramider og hviler på mellomgulvets to kupler. Innvendig i lungene finner man bronkietreet, som inneholder mange millioner lungeblærer (alveoler) og er ansvarlig for blodets tilførsel av oksygen og avsetning for karbondioksid (CO2). En prosess som er absolutt nødvendig for stoffskiftet.\r\n\r\nLungene kan hevdes å være et parti av kroppens indre overflate hvor luft kan komme inn og ut. De er utformet på en slik måte at det området som står for luftskiftet utgjør et areal på ca. 80 kvadratmeter hos et voksent menneske. Hos en rekke dyr er lungene enda større i forhold til kroppen, spesielt hos sjøpattedyr og dyr som løper eller flyr ofte og derfor har behov for større lungekapasitet.\r\n\r\nLungene er kledd med en tynn, gjennomsiktig bindevevshinne (pleura visceralis), som ved lungeroten (hilus) fortsetter over i brystskilleveggen (som pleura parietalis). Hinnen dekker også brysthulens vegg og mellomgulv. Denne sekkelignende hinnen kalles lungesekken og er dobbeltvegget og lufttett. Rommet mellom de to bladene (pleurabladene) av lungehinnen kalles pleurarommet og inneholder en tynn væske, i et svakt undertrykk, som får hinnene til å klebe seg sammen. Denne sammenklistringen medfører at lungene må utvide seg når brystkassen øker i volum. Ved lungeroten går hovedbronkien, lungearterien, lungevenen, lymfeåren og nervebaner inn og ut av lungen. I dette området finnes et antall store lymfeknuter (hilusglandlene).\r\n\r\nLungene er ellers delt i såkalte lungelapper (lobi), men høyre og venstre lunge er ikke identisk oppbygget. Hos mennesker har høyre lunge tre lungelapper (over-, midt-, og underlappen) og er størst, mens den venstre kun har to (den midtre mangler) og er mindre. Lungelappene er videre delt i mindre segmenter av bindevevsdrag.\r\n\r\nForskere har funnet ut at tobakkrøyking er årsak til opptil 10 000 genetiske mutasjoner i de aller fleste"
                },
                new DiagnoseGruppe
                {
                    diagnoseGruppeId=3,
                    beskrivelse="mage problem",
                    navn="mage",
                    dypForklaring = "Magesekken, mavesekken, eller ventrikkelen, er den delen av fordøyelsessystemet som ligger etter spiserøret. Det er den rommeligste delen av fordøyelseskanalen. Den er formet som en sterkt krummet, noe flatklemt pære og sitter i andre enden av spiserøret for munnhulen. Hos mennesket har magesekken et volumet ca. 50 ml når den er tom, men den utvider seg til ca. 1,5 liter når man har spist. I ekstreme tilfeller kan den utvide seg til å romme hele 4 liter.\r\n\r\nI cellevegene sitter det muskler (magemusklene) og små celler (kjertelceller) som skiller ut magesaft, ei sur (pH 1-3) væske som består av saltsyre (pH 0,9), enzymer (pepsin) og vann. Den sure magesaften nøytraliserer det basiske spyttet som ble tilført maten i munnhulen. Enzymene i magesaften bryter ned store molekyler til mindre enheter, samtidig som magemusklenes bevegelser (gjerne kalt peristaltiske bevegelser) elter og fordeler maten, som sendes porsjonsvis ut gjennom magesekkens nederste muskelring, kalt portneren. Enzymet pepsin begynner å spalte protein til aminosyrer. Dette pågår normalt i 3-4 timer, før den nå tyntflytende villingen (blandingen) gradvis blir tilført begynnelsen av tynntarmen (tolvfingertarmen).\r\n\r\nVann, alkohol og en del legemidler (for eksempel barbiturater og salisylsyre), kan suges opp i blodet via slimhinnen i magesekken, men ellers må stoffene i maten ut i tynntarmen før kroppen kan nyttegjøre seg næringsstoffene.\r\n\r\n\r\nFordøyelsessystemet\r\nMunnhulen Svelget Spiserøret Magesekken Tynntarmen Tykktarmen Endetarmen Spyttkjertlene Bukspyttkjertelen Leveren Galleblæren\r\nFordøyelsessystemet\r\n"
                },
                new DiagnoseGruppe
                {
                    diagnoseGruppeId=4,
                    beskrivelse="hud problem",
                    navn="hud",
                    dypForklaring = "Hud eller skinn er, innen dermatologien, det anatomiske organet, en del av bindevevssystemet, som er oppbygd av forskjellige lag som dekker de underliggende musklene og de andre organene.\r\n\r\nHudens viktigste oppgaver er å beskytte mot infeksjoner. Andre oppgaver er isolasjon, produksjon av vitamin D, formidling av sanseopplevelser og regulering av kroppens temperatur.\r\n\r\nFølesansen sitter i huden. Et voksent menneske har omtrent 2 m² hud. Tykkelsen på huden er mellom 0,2-4 mm. Huden utgjør omtrent 1/6 av den samlede kroppsvekten, og er det største organet på kroppen.\r\n\r\nHuden består av tre lag, kalt overhud (epidermis), lærhud (dermis/corium) og underhud (hypodermis/subcutis).\r\n\r\nAlle hudceller er døde. Hos mennesker vil en gjennomsnittlig voksen bære med seg ca. to og et halvt kilo død hud. Daglig mister et menneske flere milliarder små biter (hudceller)."
                }
            };
            diagnoseGrupper.ForEach((x) => db.diagnoseGruppe.Add(x));
            db.SaveChanges();

            symptomGrupper = new List<SymptomGruppe>
            {
                new SymptomGruppe
                {
                    symptomGruppeId=1,
                    beskrivelse="Hjerte problem",
                    navn="hjerte",
                    dypForklaring = "\r\nHjertet vårt slår omtrent 100.000 ganger hver eneste dag. Om hjertet slutter å slå, selv bare i noen få sekunder, så mister man bevisstheten.\r\n\r\nOm hjertet stopper opp i 3 minutter begynner hjerneceller å ta skade, og sjansen for at man våkner opp igjen reduseres med hvert påfølgende minutt. De andre organene i kroppen er fullstendig avhengige av at hjertet fungerer som det skal for å kontinuerlig forsørge dem med oksygen via blodstrømmen.\r\n\r\nAt hjertet var viktig forstod mennesket tidlig, og hjertet har derfor historisk blant annet vært sett på som sentrum av kroppen, som setet for våre emosjoner og til og med for intellektet vårt.\r\n\r\nLES OGSÅ: De første symptomene på hjertesykdom\r\n\r\nHjertets anatomi\r\nHjertet heter cor på latin. Hjertet er det første funksjonelle organet som dannes hos virveldyr. Hjertet dannes i en komplisert prosess i fosterlivet, og dannelsen begynner allerede så tidlig som 3. uke som to adskilte rør, som så i løpet av få uker forenes, gir opphav til arterier og vener, danner skillevegger og adskilte kamre, og snor seg til å få tilnærmet den formen som hjertet har senere i livet."
                },
                new SymptomGruppe
                {
                    symptomGruppeId=2,
                    beskrivelse="Lunge problem",
                    navn="lunge",
                    dypForklaring = "Mange ulike sykdommer kan ramme lungene. I denne saken presenteres de vanligste.\r\n\r\nSymptomer de fleste forbinder med lungesykdom er tung pust, en følelse av utilstrekkelig lufttilførsel (dyspne), smerter i brystet, smerter under innpust, hoste og oppspytt i form av slim eller blod. Mange av disse symptomene er også tilstede ved hjertesykdom, og oppstår da fordi et sviktende hjerte gjør lungenes oppgave mer krevende. Se egen oversikt om hjertesykdommer .\r\n\r\nLungenes funksjon:\r\nFor å forstå konsekvensen av sykdom i lungene må først lungenes funksjon i kroppen være kjent. Vi har to lunger, en på høyre og en på venstre side av brysthulen. Luftrøret (trakea) deler seg i høyre og venstre hovedbronkus som går til hver lunge. På tilsvarende måte fortsetter disse rørene og dele seg i 2 helt til et svært høyt antall supertynne rør åpner seg i små lommer. Disse lommene ligger sammen som druer i en drueklase og kalles alveoler. Et friskt menneske har flere hundre millloner alveoler."
                },
                new SymptomGruppe
                {
                    symptomGruppeId=3,
                    beskrivelse="mage problem",
                    navn="mage",
                    dypForklaring = "\r\nSymptomer fra mage- og tarmsystemet er svært vanlig. Alle har opplevd magesmerter eller løs mage. Ofte er slike plager helt ufarlig, men i noen tilfeller er det tegn på akutt og potensielt alvorlig sykdom. I denne saken skal vi se nærmere på ulik sykdom som kan ramme fordøyelseskanalen.\r\n\r\nAkutte magesmerter (akutt abdomen) er en svært vanlig problemstilling på norske sykehus. Slike smerter trenger ikke være grunnet en mage-tarmsykdom, årsaken kan like gjerne være akutt hjertesykdom, lungesykdom, nyresykdom eller gynekologisk sykdom.\r\n\r\nHvordan fungerer fordøyelseskanalen?\r\nFor å forstå ulike mage- og tarmsykdommer må man først ha noe kunnskap om organene som rammes, og deres funksjon:\r\n\r\nFordøyelseskanalen kan ses på som en kontinuerlig tube gjennom kroppen. Innholdet i tuben skilles normalt fra kroppen forøvrig mekanisk (tarmsystemet er en fysisk barriere) og immunologisk (tarmsystemet har"
                }
                ,
                new SymptomGruppe
                {
                    symptomGruppeId=4,
                    beskrivelse="andre problem",
                    navn="annet",
                    dypForklaring = "Sykdom er en fellesbetegnelse på tilstander som kjennetegnes ved forstyrrelser i kroppens normale organiske eller mentale funksjoner og forandrer dem på en skadelig måte. Enkelte sykdommer er helt lokale, det vil si at de bare angriper og gir symptomer i et enkelt organ uten påvirkning av allmenntilstanden, for eksempel brokk og enkelte svulster. Andre ganger medfører en lokal sykdom en allmennlidelse med generell sykdomsfølelse, slapphet eller feber, for eksempel lungebetennelse. Mange sykdommer påvirker hele kroppen, som for eksempel infeksjoner, forstyrrelser i vitamin- og hormonhusholdning og blodsykdommer.\r\n\r\nBegrepet sykdom er vanskelig å definere, og det har hatt en tendens til stadig å bli utvidet.\r\n\r\nLes mer: sykdomsbegrep\r\nPå 1800-tallet ble sykdom ofte identifisert og definert ved patologisk-anatomiske forandringer i organene og vevene. Senere har man også tatt funksjonelle forstyrrelser uten patologisk-anatomiske funn inn i begrepet. Derfor inngår nå hodepine, smertetilstander og psykiske plager i sykdomsbegrepet.\r\n\r\nKlinisk sykdom"
                }
            };
            symptomGrupper.ForEach((x) => db.symptomGruppe.Add(x));
            db.SaveChanges();


            diagnoser = new List<Diagnose>()
            {

                new Diagnose
                {
                    diagnoseId = 1,
                    beskrivelse = "vondt i venstre-del av hjerte",
                    diagnoseGruppeId = 1,
                    navn = "venstre-del hjerte sykdommen",
                    dypForklaring = "Det kan oppstå mange ulike sykdommer i hjertet og i sirkulasjonssystemet. Koronarsykdom forekommer hyppig og skyldes åreforkalkning (aterosklerose) på innsiden av hjertets arterier. Dette medfører blant annet at arteriene blir trangere og stivere. Det er dermed en risiko for at de ikke kan tilføre hjertemuskelen nok næring og oksygen. Dette vil først merkes under fysiske anstrengelser når underskudd på blod til hjertemuskelen forårsaker brystsmerter. Når en koronararterie tettes helt igjen, dør den delen av hjertet som er avhengig av blodtilførsel fra denne arterien, og det oppstår et hjerteinfarkt. Den samme mekanismen kan blant annet føre til hjerneslag i hjernen eller sirkulasjonsproblemer i beina."
                },
                      new Diagnose
                {
                  diagnoseId = 2,
                    beskrivelse = "vondt i høyre-del av hjerte",
                    diagnoseGruppeId = 1,
                    navn = "høyre-del hjerte sykdommen",
                    dypForklaring = "Hjerteslagene er normalt regelmessige. Hvert hjerteslag utløses av et elektrisk signal som starter i hjertets høyre forkammer og som følger hjertets elektriske ledningssystem over til venstre forkammer og deretter venstre og høyre hjertekammer. Dette signalet får hjertet til å trekke seg sammen på en bestemt måte: Sammentrekningen starter i forkamrene som tømmer blodet inn i hjertekamrene, deretter trekker hjertekamrene seg sammen og skyver blodet ut i kroppen (venstre hjertekammer) og til lungene (høyre hjertekammer). Skader på det elektriske ledningssystemet kan føre til at hjertet slår uregelmessig (arytmi). Hjertet arbeider da mindre effektivt."
                },
                            new Diagnose
                {
                    diagnoseId = 3,
                    beskrivelse = "vondt i venstre lunge",
                    diagnoseGruppeId = 2,
                    navn = "venstre lunge sykdom",
                    dypForklaring = "For å forstå konsekvensen av sykdom i lungene må først lungenes funksjon i kroppen være kjent. Vi har to lunger, en på høyre og en på venstre side av brysthulen. Luftrøret (trakea) deler seg i høyre og venstre hovedbronkus som går til hver lunge. På tilsvarende måte fortsetter disse rørene og dele seg i 2 helt til et svært høyt antall supertynne rør åpner seg i små lommer. Disse lommene ligger sammen som druer i en drueklase og kalles alveoler. Et friskt menneske har flere hundre millloner alveoler.\r\n\r\nFem varselsignaler på lungesykdom\r\nFem varselsignaler på lungesykdom\r\nRundt hver alveole går det svært tynne blodårer, dette gjør at avstanden blir så liten at gassen kan passivt overføres. Hvordan skjer dette? La oss ta et eksempel de fleste kjenner til: Brus inneholder kullsyre, som er karbondioksid, løst i vann. Av erfaring vet vi at brusen holder seg svært lenge i flasken, helt til den er åpnet. Etter relativt kort tid blir brusen «tam». Det som da har skjedd er karbondioksiden, som var løst væsken, har passivt boblet ut i luften fordi konsentrasjonen av gassen var mye høyere i brusen enn i luften rundt. Brusen blir fortere tam når du heller den på et glass, enn hvis den kun står med korken åpen., - det er fordi overflaten der luft og væske møtes er større i glasset enn i flasken. Lungene fungerer på samme måte og for å effektivisere denne prosessen er det millioner av slike lommer for å skape en størst mulig møteplass mellom væske (blod) og luft."
                },      new Diagnose
                {
                    diagnoseId = 4,
                    beskrivelse = "vondt i høyre lunge",
                    diagnoseGruppeId = 2,
                    navn = "høyre lunge sykdom",
                    dypForklaring = "\r\nKOLS medfører ulik grad av:\r\n\r\nObstruktivitet: Obstruktivitet er det samme symptomet som ses ved astma. Langvarig betennelse gir innskrenkning og endring av luftveiene. Ved KOLS er obstruktivitet mer kronisk enn ved astma, det betyr at endringene i større grad er tilstede hele tiden og responderer dårligere på medisiner.\r\nEmfysem: Emfysem medfører tap av veggen i alveolene. Som tidligere forklart er det essensielt for lungefunksjonen at det er et stort overflateareal der væske og luft kan møtes for gassutveksling. Ved emfysem minsker dette arealet fordi flere alveoler kollapser til en større (se for deg at en hel drueklase knuses og bare danner et stort rom).\r\nKOLS behandles med de samme medisinene som astma, i tillegg oksygenbehandling ved alvorlig sykdom og sist men ikke minst røykeslutt."
                },      new Diagnose
                {
                    diagnoseId = 5,
                    beskrivelse = "vondt i tarm",
                    diagnoseGruppeId = 3,
                    navn = "tarm sykdommen",
                    dypForklaring = "Norovirus er den vanlegaste årsaken til omgangssjuke eller smittsam mage- og tarmsjukdom. Viruset er ansvarleg for minst 50 prosent av alle utbrot med mage- og tarminfeksjon på verdsbasis.\r\n\r\nUtbrot av norovirus inntreff gjerne om vinteren i Noreg. Personar i alle aldersgrupper kan bli smitta og sjuke.\r\n\r\nRotavirussjukdom er også ein mage- tarminfeksjon som gjev oppkast, diaré og ofte feber hos sped- og småbarn.\r\n\r\nSymptom og smitte ved norovirus\r\nSjukdommen er vanlegvis mild og går over av seg sjølv etter ein til tre dagar hos elles friske personar.\r\n\r\nDet tek 12–48 timer frå ein blir smitta til ein blir sjuk. Symptoma er \r\n\r\nakutt kvalme \r\noppkast \r\nmagesmerter \r\ndiaré\r\nI tillegg får mange influensaliknande symptom som\r\n\r\nfeber\r\nmuskel- og leddverk\r\nhovudpine\r\nEin smitta person er mest smittsam medan han/ho har symptom med oppkast og diaré, men kan òg vere smitteførande etter at symptoma gir seg. Etter 48 timer skil dei fleste ut mindre smittestoff."
                },      new Diagnose
                {
                    diagnoseId = 6,
                    beskrivelse = "vondt i makesekk",
                    diagnoseGruppeId = 3,
                    navn = "magesekk sykdommen",
                    dypForklaring = "Magesår (ulcus pepticum) er sår i slimhinnen i magesekken (ventrikkel) eller øvre del av tolvfingertarmen (duodenum). Magesårsykdommen oppfattes i dag som en infeksjonssykdom forårsaket av bakterien Helicobacter pylori (Hp) - magesårsbakterien. Vi regner at 99 prosent av tolvfingertarmsårene (duodenalsår) og 75 prosent av magesekksårene (ventrikkelsår) skyldes infeksjon i slimhinnen med Helicobacter pylori. 25 prosent av sårene i magesekken skyldes den etsende virkningen som medisingruppene salisylater (Aspirin), klopidogrel (Plavix) og NSAIDs (eks. Naproxen) kan ha på slimhinnen i magesekken.\r\n\r\nEt typisk trekk ved magesår er at slike sår kommer igjen og igjen. Det er ca. 75 prosent sjanse for at en person som har hatt et magesår, vil få et nytt sår innen ett år er gått dersom ikke infeksjonen med Helicobacter pylori er fjernet. "
                }
            };
            diagnoser.ForEach((x) => db.diagnose.Add(x));
            db.SaveChanges();

            symptomer = new List<Symptom>()
            {
                new Symptom
                {
                    beskrivelse = "problemet med syre",
                    navn = "syre problem i magesekk",
                    symptomId = 1,

                    symptomGruppeId =3,
                    dypForklaring = "Tilfeldig dyp forklaring for problemet med syre "
                },
                   new Symptom
                {
                    beskrivelse = "vondt i lunge",
                    navn = "vondt i lunge",
                    symptomId = 2,

                    symptomGruppeId= 2,
                    dypForklaring = "Tilfeldig dyp forklaring for problemet med vondt i lunge"
                },   new Symptom
                {
                    beskrivelse = "vondt i mage",
                    navn = "vondt i mage",
                    symptomId = 3,

                    symptomGruppeId =3,
                    dypForklaring = "Tilfeldig dyp forklaring for problemet med vondt i mage"
                },   new Symptom
                {
                    beskrivelse = "vondt i hjerte",
                    navn = "vondt i hjerte",
                    symptomId = 4,
                   symptomGruppeId=1,
                   dypForklaring = "Tilfeldig dyp forklaring for problemet med vondt i hjerte"
                },   new Symptom
                {
                    beskrivelse = "har hodepine",
                    navn = "hodepine",
                    symptomId = 5,

                   symptomGruppeId=4,
                   dypForklaring = "Tilfeldig dyp forklaring for problemet med hodepine"
                },   new Symptom
                {
                    beskrivelse = "er kvalm",
                    navn = "opplever kvalme",
                    symptomId = 6,
                   symptomGruppeId=4,
                   dypForklaring = "Tilfeldig dyp forklaring for problemet med kvalme"
                }
            };
            symptomer.ForEach((x) => db.symptom.Add(x));
            db.SaveChanges();


            symptomBilder = new List<SymptomBilde>
            {
                new SymptomBilde
                {
                    diagnoseId = 1,
                    symptomBildeId = 1,
                    beskrivelse = "herte problem",
                    navn = "hjerte vansker",
                    dypForklaring = "123"
                },
                   new SymptomBilde
                {
                    diagnoseId = 4,
                    symptomBildeId = 2,
                    beskrivelse = "lunge problem",
                    navn = "lunge vansker",
                    dypForklaring = "123"
                },
                      new SymptomBilde
                {
                    diagnoseId = 1,
                    symptomBildeId = 3,
                    beskrivelse = "herte har fått hull",
                    navn = "hjerte vansker",
                    dypForklaring = "123"
                }, new SymptomBilde
                {
                    diagnoseId = 2,
                    symptomBildeId = 4,
                    beskrivelse = "lunge punktert",
                    navn = "lunge punktert",
                    dypForklaring = "123"
                },
                   new SymptomBilde
                {
                    diagnoseId = 3,
                    symptomBildeId = 5,
                    beskrivelse = "lunge problem",
                    navn = "lunge vansker",
                    dypForklaring = "123"
                },
                      new SymptomBilde
                {
                    diagnoseId = 5,
                    symptomBildeId = 6,
                    beskrivelse = "tarm har fått hull",
                    navn = "tarm vansker",
                    dypForklaring = "123"
                }, new SymptomBilde
                {
                    diagnoseId = 5,
                    symptomBildeId = 7,
                    beskrivelse = "tarm har tat fyr",
                    navn = "tarm brann",
                    dypForklaring = "123"
                }


            };
            symptomBilder.ForEach((x) => db.symptomBilde.Add(x));
            db.SaveChanges();

            symptomSymptomBilder = new List<SymptomSymptomBilde>
            {
                new SymptomSymptomBilde
                {
                    symptomBildeId = 7,
                                         varighet = 2,
                    symptomId =1
                },
                new SymptomSymptomBilde
                {
                    symptomBildeId = 6,
                                         varighet = 1,
                    symptomId =3
                },
                    new SymptomSymptomBilde
                {
                    symptomBildeId = 3,
                                         varighet =3,
                    symptomId =4
                },
                    new SymptomSymptomBilde
                {
                    symptomBildeId =5,
                                         varighet = 1,
                    symptomId =2
                },
                new SymptomSymptomBilde
                {
                    symptomBildeId = 1,
                                         varighet = 2,
                    symptomId =4
                },
                new SymptomSymptomBilde
                {
                    symptomBildeId = 6,
                                         varighet = 4,
                    symptomId =1
                }
        };
            symptomSymptomBilder.ForEach((x) => db.symptomSymptomBilde.Add(x));
            db.SaveChanges();

            return app;
        }
    }

}