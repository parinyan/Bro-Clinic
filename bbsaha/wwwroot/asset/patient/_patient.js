new Vue({
    el: "#_patient",
    data: function () {
        return {
            cncode: "",
            titlen: "",
            fname: "",
            lname: "",
            gender: "",
            idcard: "",
            idpart: "",
            adr: "",
            tanon: "",
            tambon: "",
            ampur: "",
            province: "",
            postcode: "",
            career: "",
            tel: "",
            birthday: "",
            yearV: "",
            monthV: "",
            dayV: "",
            age: "",
            idpat: "",
            idrun: "",

            cncodee: "",
            titlene: "",
            fnamee: "",
            lnamee: "",
            gendere: "",
            idcarde: "",
            idparte: "",
            adre: "",
            tanone: "",
            tambone: "",
            ampure: "",
            provincee: "",
            postcodee: "",
            careere: "",
            tele: "",
            birthdaye: "",
            yearVe: "",
            monthVe: "",
            dayVe: "",
            agee: "",
            idpate: "",
            idrune: "",

            formsubmit: [{}],
            formmed: [{}],
            formsubmitE: [{}],
            DEformsubmit: [{}],
            DEformsubmitE: [{}],
            formsubmitsel: [{}],
            formsubmitselE: [{}],
            getprovince: [],
            getdistrict: [],
            getsubdistrict: [],
            getpostcode: [],
            getdatapatirnt: [],
            getdatadetail: [],


            DE_date: new Date().toISOString().slice(0, 10),
            DE_time:"",
          

            DE_datee: new Date().toISOString().slice(0, 10),
            DE_timee: new Date().getHours() + ":" + (new Date().getMinutes() < 10 ? '0' : '') + new Date().getMinutes() ,
            DE_customere: {comname: "-",code: 2},
            DE_heighte: "",
            DE_weighte: "",
            DE_bpe: "",
            DE_customere2: "",
            DE_pulsee: "",
            DE_bpme: "",
            DE_alcohole: "1",
            DE_cigare: "1",
            DE_servicee: "",
            DE_hissicke: "ไม่มี",
            DE_hispharae: "ไม่มี",
            DE_bloodgre: "",
            DE_sodiume: "",
            DE_potassiume: "",
            DE_chloridee: "",
            DE_totalco2e: "",
            DE_uricacide: "",
            DE_bune: "",
            DE_creatininee: "",
            DE_choiesterole: "",
            DE_triglyceridee: "",
            DE_hdlce: "",
            DE_ldlce: "",
            DE_totalproteine: "",
            DE_albumine: "",
            DE_globuline: "",
            DE_totalbilirubine: "",
            DE_directe: "",
            DE_sgote: "",
            DE_sgpte: "",
            DE_alke: "",
            DE_fbse: "",
            DE_amphetaminee: "",
            DE_pregnancye: "",
            DE_hbsage: "",
            DE_hbsagbe: "",
            DE_antihavtotale: "",
            DE_antihavigme: "",
            DE_vdrle: "",
            DE_antihive: "",
            DE_tshe: "",
            DE_freet3e: "",
            DE_freet4e: "",
            DE_t3e: "",
            DE_t4e: "",
            DE_hemoglobine: "",
            DE_hematocrite: "",
            DE_wbce: "",
            DE_lyme: "",
            DE_grane: "",
            DE_mide: "",
            DE_platelete: "",
            DE_eyecolore: "",
            DE_xraye: "",
            DE_s1e: "",
            DE_s2e: "",
            DE_s3e: "",
            DE_s4e: "",
            DE_s5e: "",
            DE_s6e: "",
            DE_s7e: "",
            DE_s8e: "",
            DE_number:"",
            DE_numbere: "",
            DE_colore: "",
            DE_phe: "",
            DE_protiene: "",
            DE_sg: "",
            DE_glucosee: "",
            DE_ketonee: "",
            DE_bilirubine: "",
            DE_urobilinogene: "",
            DE_bloode: "",
            DE_leukocytee: "",
            DE_nitritee: "",
            DE_urin1e: "",
            DE_urin2e: "",
            DE_stoolexe: "",
            DE_stoolcule: "",
            DE_hissickbodye: "",
            DE_hisfoode: "",
            DE_hissickworke: "",
            DE_labinvese: "",
            DE_wbcdife: "",
            DE_ascorbice: "",
            DE_dif4e: "",
            DE_dif5e: "",
            DE_claritye: "",
            DE_stoolexe: "",
            DE_stoolcue: "",
            DE_mcv: "",
            DE_mch: "",
            DE_mchc: "",

            CheckHis: "",
            disabled: 0,
            refnosel: "",
            namesel: "",

            mednosel: "",
            fnamesel: "",
            lnamesel: "",
            titlesel: "",
            datesel: "",
            cnsel: "",
            customersel: "",
            prisel: "",
            moneyresel: "",
            remarksel: "",
            repaydatesel: "",
            rededatesel: "",
            reccomsel: "",
            paymentsel: "",
            medtypesel: "",
            idsel:"",

            getdatamedty: [],
            getdatapayty: [],
            getdatareciveper: [],
            getdatacompany: [],
            getdatachkty: [],
            getdatarec: [],
            formsubmit: [{}],
            formsubmitE: [{}],

            idpae: "",
            iddetaile: "",
            chkdupil: false,
            chkdetailedit: false,
            chkselpayment: [],
            butchkpayment:0,
            medtypewalk: "",
            searchhc: [],
            chkselectpatient: 0,
            idpayment: [],


            titlenmd: "",
            fnamemd: "",
            lnamemd: "",
            adrmd: "",
            idcardmd: "",
            ch1md: "",
            ch2md: "",
            ch3md: "",
            ch4md: "",
            tex1md: "",
            tex2md: "",
            tex3md: "",
            tex4md: "",
            tex5md: "",
            tex6md: "",
            weightmd: "",
            heightmd: "",
            bloodmd: "",
            pulsemd: "",
            ch6md: "",
            tex6: "",
            commentmd: "",
            DateCusmd: new Date().toISOString().slice(0, 10),
            chkmededit: false,
            typemedcer: "",
            timemd: new Date().getHours() + ":" + (new Date().getMinutes() < 10 ? '0' : '') + new Date().getMinutes(),
            ideditmed: ""



            


        }

    }, methods: {
        searchpatirnt(ser) {
            axios.get("/Patient/Getdatapatient", {
                params: {
                    sercon: this.searchhc,
                    

                }
            })
                .then(res => {
                    /* console.log(res.data);*/
                    this.getdatapatirnt = res.data

                }).catch(err => {
                    console.log(err);
                })
        },
        Getdataeditdetail(id) {
           /* console.log(this.DE_customere)*/
            this.disabled = 0
            axios.get("/Patient/Getdataeditdetail",
                {
                    params: {
                        id: id

                    }
                })
                .then(res => {

                  
                
                    const myArray = res.data[0].bpm.split("/")
                    
                    /* this.getdatadetail = res.data*/
                    this.DE_datee = res.data[0].labinves
                    this.DE_timee = res.data[0].time
                    this.DE_customere.comname = (res.data[0].customer == "" || res.data[0].service == "191" ? "-" : res.data[0].customer)
                    this.DE_customere2 = (res.data[0].service == "191" ? res.data[0].customer : "")
                    this.DE_customere.code = (res.data[0].customer == "" || res.data[0].service == "191" ? "0" : res.data[0].service)
                    this.DE_heighte = res.data[0].height
                    this.DE_weighte = res.data[0].weight
                   
                    this.DE_pulsee = res.data[0].pulse
                    this.DE_bpme = myArray[0]
                    this.DE_bpe = myArray[1]
                    this.DE_alcohole = res.data[0].alcohol
                    this.DE_cigare = res.data[0].cigar
                    this.DE_servicee = res.data[0].service
                    this.DE_hissicke = res.data[0].hisSick
                    this.DE_hispharae = res.data[0].hisphara
                    this.DE_bloodgre = res.data[0].bloodgr
                    this.DE_sodiume = res.data[0].sodium
                    this.DE_potassiume = res.data[0].potassium
                    this.DE_chloridee = res.data[0].chloride
                    this.DE_totalco2e = res.data[0].totalco2
                    this.DE_uricacide = res.data[0].uricacid
                    this.DE_bune = res.data[0].bun
                    this.DE_creatininee = res.data[0].creatinine
                    this.DE_choiesterole = res.data[0].choiesterol
                    this.DE_triglyceridee = res.data[0].triglyceride
                    this.DE_hdlce = res.data[0].hdlc
                    this.DE_ldlce = res.data[0].ldlc
                    this.DE_totalproteine = res.data[0].totalpro
                    this.DE_albumine = res.data[0].albumin
                    this.DE_globuline = res.data[0].globulin
                    this.DE_totalbilirubine = res.data[0].totalbilirubin
                    this.DE_directe = res.data[0].direct
                    this.DE_sgote = res.data[0].sgot
                    this.DE_sgpte = res.data[0].sgpt
                    this.DE_alke = res.data[0].alk
                    this.DE_fbse = res.data[0].fbs
                    this.DE_amphetaminee = res.data[0].amphetamine
                    this.DE_pregnancye = res.data[0].pregnancy
                    this.DE_hbsage = res.data[0].hbsag
                    this.DE_hbsagbe = res.data[0].hbsagb
                    this.DE_antihavtotale = res.data[0].antihavtotal
                    this.DE_antihavigme = res.data[0].antihavlgm
                    this.DE_vdrle = res.data[0].vdrl
                    this.DE_antihive = res.data[0].antihiv
                    this.DE_tshe = res.data[0].tsh
                    this.DE_freet3e = res.data[0].freet3
                    this.DE_freet4e = res.data[0].freet4
                    this.DE_t3e = res.data[0].t3
                    this.DE_t4e = res.data[0].t4
                    this.DE_hemoglobine = res.data[0].hemoglobin
                    this.DE_hematocrite = res.data[0].hematocrit
                    this.DE_wbce = res.data[0].wbc
                    this.DE_lyme = res.data[0].lym
                    this.DE_grane = res.data[0].gran
                    this.DE_mide = res.data[0].mid
                    this.DE_platelete = res.data[0].platelet
                    this.DE_mcv = res.data[0].mcv
                    this.DE_mch = res.data[0].mch
                    this.DE_mchc = res.data[0].mchc
                    this.DE_eyecolore = res.data[0].eyecolor
                    this.DE_xraye = res.data[0].xray
                    this.DE_s1e = res.data[0].s1
                    this.DE_s2e = res.data[0].s2xray
                    this.DE_s3e = res.data[0].s3cbc
                    this.DE_s4e = res.data[0].s4cigar
                    this.DE_s5e = res.data[0].s5chid
                    this.DE_s6e = res.data[0].s6viral
                    this.DE_s7e = res.data[0].s7cbc
                    this.DE_s8e = res.data[0].s8
                    this.DE_numbere = res.data[0].iDdate + (res.data[0].iDrunnumber > 999 ? "-" : (res.data[0].iDrunnumber > 99 ? "-0" : (res.data[0].iDrunnumber > 9 ? "-00" : "-000"))) + res.data[0].iDrunnumber;
                    this.DE_colore = res.data[0].color
                    this.DE_phe = res.data[0].ph
                    this.DE_protiene = res.data[0].protien
                    this.DE_sg = res.data[0].sg
                    this.DE_urin1e = res.data[0].urin1
                    this.DE_urin2e = res.data[0].urin2
                    this.DE_stoolexe = res.data[0].stoolex
                    this.DE_stoolcule = res.data[0].stoolcul
                    this.DE_hissickbodye = res.data[0].hissickbody
                    this.DE_hisfoode = res.data[0].hisfood
                    this.DE_hissickworke = res.data[0].hissickwork
                    this.DE_labinvese = res.data[0].labinves
                    this.DE_stoolexe = res.data[0].stoolex
                    this.DE_stoolcue = res.data[0].stoolcul
                    this.DE_dif4e = res.data[0].diff4
                    this.DE_dif5e = res.data[0].diff5
                    this.DE_claritye = res.data[0].clarity
                    this.DE_glucosee = res.data[0].glucose
                    this.DE_ketonee = res.data[0].ketone
                    this.DE_bilirubine = res.data[0].bilirubin
                    this.DE_urobilinogene = res.data[0].urobilinogen
                    this.DE_bloode = res.data[0].blood
                    this.DE_leukocytee = res.data[0].leukocyte
                    this.DE_nitritee = res.data[0].nitrite
                    this.DE_ascorbice = res.data[0].ascorbic
                    this.DE_dif4e = res.data[0].dif4
                    this.DE_dif5e = res.data[0].dif5
                    this.iddetaile = res.data[0].id
                    this.medtypewalk = res.data[0].medtype
                    //this.idrune = res.data.titlename;

                    
                    this.chkdetailedit = true
                   /* console.log(this.DE_customere)*/
                    //console.log(res.data[0].labinves);
                    //console.log(this.DE_numbere)

                    this.getdatachktype()
                }).catch(err => {
                    console.log(err);
                })

            $("#home").addClass("show active");
            $("#home-tab").addClass("active");
            $("#contact").removeClass("show active");
            $("#contact-tab").removeClass("active");
            $("#med").removeClass("show active");
            $("#med-tab").removeClass("active");
        },
        Getdataemeddetail(id) {
            /* console.log(this.DE_customere)*/
            this.disabled = 0
            axios.get("/medic/Getdatameddetail",
                {
                    params: {
                        id: id

                    }
                })
                .then(res => {
                    var da = new Date(res.data.cerDate)
                   /* const myArray = res.data[0].bpm.split("/")*/
                    /* this.getdatadetail = res.data*/
                   /* this.DE_datee = res.data[0].labinves*/
                    this.ideditmed = id
                    //this.idrune = res.data.titlename;
                    this.typemedcer = res.data.type

                    if (res.data.type == 1) {
                        this.fnamemd = res.data.firstNameCus
                        this.lnamemd = res.data.lastNameCus
                        this.adrmd = res.data.addressCus
                        this.idcardmd = res.data.idcardCus
                        this.ch1md = (res.data.check_1 == true ? "Two" : "One")
                        this.ch2md = (res.data.check_2 == true ? "Two" : "One")
                        this.ch3md = (res.data.check_3 == true ? "Two" : "One")
                        this.tex1md = res.data.detail_1
                        this.tex2md = res.data.detail_2
                        this.tex3md = res.data.detail_3

                        this.tex5md = res.data.detail_5
                        this.tex6md = res.data.body_healthDetailCus
                        this.weightmd = res.data.weightCus
                        this.heightmd = res.data.heightCus
                        this.bloodmd = res.data.blood_pressureCus
                        this.pulsemd = res.data.pulseCus
                        this.ch6md = (res.data.body_healthStatusCus == true ? "Two" : "One")
                        this.commentmd = res.data.commentCom
                        this.DateCusmd = new Date(da.setDate(da.getDate() + 1)).toISOString().slice(0, 10)

                    } else if (res.data.type == 2) {
                        this.fnamemd = res.data.firstNameCus
                        this.lnamemd = res.data.lastNameCus
                        this.adrmd = res.data.addressCus
                        this.idcardmd = res.data.idcardCus
                        this.ch1md = (res.data.check_1 == true ? "Two" : "One")
                        this.ch2md = (res.data.check_2 == true ? "Two" : "One")
                        this.ch3md = (res.data.check_3 == true ? "Two" : "One")
                        this.ch4md = (res.data.check_4 == true ? "Two" : "One")

                        this.tex1md = res.data.detail_1
                        this.tex2md = res.data.detail_2
                        this.tex3md = res.data.detail_3
                        this.tex4md = res.data.detail_4

                        this.tex5md = res.data.detail_5
                        this.tex6md = res.data.body_healthDetailCus
                        this.weightmd = res.data.weightCus
                        this.heightmd = res.data.heightCus
                        this.bloodmd = res.data.blood_pressureCus
                        this.pulsemd = res.data.pulseCus
                        this.ch6md = (res.data.body_healthStatusCus == true ? "Two" : "One")
                        this.commentmd = res.data.commentCom
                        this.DateCusmd = new Date(da.setDate(da.getDate() + 1)).toISOString().slice(0, 10)

                    } else if (res.data.type == 3) {

                        this.fnamemd = res.data.firstNameCus
                        this.lnamemd = res.data.lastNameCus
                        this.adrmd = res.data.addressCus
                        this.idcardmd = res.data.idcardCus
                        //this.ch1md = (res.data.check_1 == true ? "Two" : "One")
                        //this.ch2md = (res.data.check_2 == true ? "Two" : "One")
                        //this.ch3md = (res.data.check_3 == true ? "Two" : "One")
                        //this.ch4md = (res.data.check_4 == true ? "Two" : "One")

                        //this.tex1md = res.data.detail_1
                        //this.tex2md = res.data.detail_2
                        //this.tex3md = res.data.detail_3
                        //this.tex4md = res.data.detail_4
                        this.DateCusmd = new Date(da.setDate(da.getDate() + 1)).toISOString().slice(0, 10)
                        this.tex5md = res.data.detail_5
                        //this.weightmd = res.data.weightCus
                        //this.heightmd = res.data.heightCus
                      /*  this.bloodmd = res.data.blood_pressureCus*/
                        //this.pulsemd = res.data.pulseCus
                        this.tex6md = res.data.body_healthDetailCus
                        this.ch6md = (res.data.body_healthStatusCus == true ? "Two" : "One")
                        this.commentmd = res.data.commentCom


                    }
                    //this.fnamemd = res.data.firstNameCus
                    //this.fnamemd = res.data.firstNameCus

                   
                    this.chkmededit = true
                    /* console.log(this.DE_customere)*/
                    //console.log(res.data);
                    //console.log(new Date(da.setDate(da.getDate() + 1)).toISOString());
                    //console.log(this.DE_numbere)

                    /*this.getdatachktype()*/
                }).catch(err => {
                    console.log(err);
                })

            $("#home").removeClass("show active");
            $("#home-tab").removeClass("active");

            $("#contact").removeClass("show active");
            $("#contact-tab").removeClass("active");

            $("#med").addClass("show active");
            $("#med-tab").addClass("active");

           
        },
        getdatapay(id,chk) {
            axios.get("/Patient/Getdatapay",
                {
                    params: {
                        id: id

                    }
                })
                .then(res => {
                   /* console.log(res.data);*/
                    this.cnsel = res.data[0].age;
                    this.mednosel = res.data[0].refno;
                    this.fnamesel = res.data[0].mid
                    this.lnamesel = res.data[0].name
                    this.datesel = res.data[0].date
                    this.titlesel = res.data[0].direct
                    this.customersel = res.data[0].company
                    this.idsel = res.data[0].id

                    this.prisel = res.data[0].totalse
                    this.medtypesel = res.data[0].medtyse
                    this.paymentsel = res.data[0].paytyse
                    this.moneyresel = res.data[0].moneyse
                    this.repaydatesel = res.data[0].repaydatese
                    this.rededatesel = res.data[0].rededatese
                    this.reccomsel = res.data[0].reccomse
                    this.butchkpayment = chk
                    this.medtypesel = res.data[0].medtype

                    this.getdatareca()
                }).catch(err => {
                    console.log(err);
                })
            $("#contact").addClass("show active");
            $("#contact-tab").addClass("active");

            $("#home").removeClass("show active");
            $("#home-tab").removeClass("active");

            $("#med").removeClass("show active");
            $("#med-tab").removeClass("active");
        },
        setrefno(id) {



            axios.get("/Patient/Getdatadig",
                {
                    params: {
                        id: id

                    }
                })
                .then(res => {

                    this.refnosel = "BB-" + res.data[0].idPatient + (res.data[0].iDrunnumber > 9 ? "-00" : (res.data[0].iDrunnumber > 99 ? "-0" : (res.data[0].iDrunnumber >= 999 ? "-" : "-000"))) + res.data[0].iDrunnumber;
                    this.namesel = res.data[0].fname + " " + res.data[0].lname
                    this.DE_number = id
                    /* console.log(this.refnosel)*/
                    this.chkdetailedit = false
                    this.chkmededit = false
                  

                    this.DE_datee = new Date().toISOString().slice(0, 10)
                    this.DE_timee = new Date().getHours() + ":" + (new Date().getMinutes() < 10 ? '0' : '') + new Date().getMinutes()
                   /* this.DE_customere = { comname: "-", code: 0 }*/
                    this.DE_heighte = ""
                    this.DE_weighte = ""
                    this.DE_bpe = ""
                    this.DE_pulsee = ""
                    this.DE_bpme = ""
                    this.DE_alcohole = "1"
                    this.DE_cigare = "1"
                    this.DE_servicee = ""
                    this.DE_hissicke = "ไม่มี"
                    this.DE_hispharae = "ไม่มี"
                    this.DE_bloodgre = ""
                    this.DE_sodiume = ""
                    this.DE_potassiume = ""
                    this.DE_chloridee = ""
                    this.DE_totalco2e = ""
                    this.DE_uricacide = ""
                    this.DE_bune = ""
                    this.DE_creatininee = ""
                    this.DE_choiesterole = ""
                    this.DE_triglyceridee = ""
                    this.DE_hdlce = ""
                    this.DE_ldlce = ""
                    this.DE_totalproteine = ""
                    this.DE_albumine = ""
                    this.DE_globuline = ""
                    this.DE_totalbilirubine = ""
                    this.DE_directe = ""
                    this.DE_sgote = ""
                    this.DE_sgpte = ""
                    this.DE_alke = ""
                    this.DE_fbse = ""
                    this.DE_amphetaminee = ""
                    this.DE_pregnancye = ""
                    this.DE_hbsage = ""
                    this.DE_hbsagbe = ""
                    this.DE_antihavtotale = ""
                    this.DE_antihavigme = ""
                    this.DE_vdrle = ""
                    this.DE_antihive = ""
                    this.DE_tshe = ""
                    this.DE_freet3e = ""
                    this.DE_freet4e = ""
                    this.DE_t3e = ""
                    this.DE_t4e = ""
                    this.DE_hemoglobine = ""
                    this.DE_hematocrite = ""
                    this.DE_wbce = ""
                    this.DE_lyme = ""
                    this.DE_grane = ""
                    this.DE_mide = ""
                    this.DE_platelete = ""
                    this.DE_mcv = ""
                    this.DE_mch = ""
                    this.DE_mchc = ""
                    this.DE_eyecolore = ""
                    this.DE_xraye = ""
                    this.DE_s1e = ""
                    this.DE_s2e = ""
                    this.DE_s3e = ""
                    this.DE_s4e = ""
                    this.DE_s5e = ""
                    this.DE_s6e = ""
                    this.DE_s7e = ""
                    this.DE_s8e = ""
                    this.DE_numbere = [];
                    this.DE_colore = ""
                    this.DE_phe = ""
                    this.DE_protiene = ""
                    this.DE_sg = ""
                    this.DE_urin1e = ""
                    this.DE_urin2e = ""
                    this.DE_stoolexe = ""
                    this.DE_stoolcule = ""
                    this.DE_hissickbodye = ""
                    this.DE_hisfoode = ""
                    this.DE_hissickworke = ""
                    this.DE_labinvese = ""
                    this.DE_stoolexe = ""
                    this.DE_stoolcue = ""
                    this.DE_dif4e = ""
                    this.DE_dif5e = ""
                    this.DE_claritye = ""
                    this.DE_glucosee = ""
                    this.DE_ketonee = ""
                    this.DE_bilirubine = ""
                    this.DE_urobilinogene = ""
                    this.DE_bloode = ""
                    this.DE_leukocytee = ""
                    this.DE_nitritee = ""
                    this.DE_ascorbice = ""
                    this.DE_dif4e = ""
                    this.DE_dif5e = ""
                    this.iddetaile = ""
                    this.medtypewalk = ""
                    this.prisel = ""
                    this.medtypesel = ""
                    this.paymentsel = ""
                    this.moneyresel = ""
                    this.repaydatesel = ""
                    this.rededatesel = ""
                    this.reccomsel = ""
                    this.cnsel = "";
                    this.mednosel = "";
                    this.fnamesel = ""
                    this.lnamesel = ""
                    this.datesel = ""
                    this.titlesel = ""
                    this.customersel = ""
                    this.idsel = ""

                 
                    this.ch1md = ""
                    this.ch2md = ""
                    this.ch3md = ""
                    this.tex1md = ""
                    this.tex2md = ""
                    this.tex3md = ""

                    this.tex5md = ""
                    this.tex6md = ""
                    this.weightmd = ""
                    this.heightmd = ""
                    this.bloodmd = ""
                    this.pulsemd = ""
                    this.ch6md = ""
                    this.commentmd = ""


                    this.typemedcer = ""

                    this.chkselectpatient = 1
                }).catch(err => {
                    console.log(err);
                })



            axios.get("/medic/Getdatamedcer",
                {
                    params: {
                        id: id

                    }
                })
                .then(res => {

                    /*console.log(res.data);*/
                  
                    this.titlenmd = res.data[0].titlename
                    this.fnamemd = res.data[0].fname
                    this.lnamemd = res.data[0].lname
                    this.idcardmd = res.data[0].idCard
                    this.adrmd = res.data[0].address + " " + res.data[0].subDistrict + " " + res.data[0].district + " " + res.data[0].province + " " + res.data[0].postcode
                  

                  
                }).catch(err => {
                    console.log(err);
                })

            /*alert("s")*/
            this.getdatadet(id)

        },
        editdetail() {

            this.DEformsubmitE[0].date = this.DE_datee
            this.DEformsubmitE[0].time = this.DE_timee
            /*this.DEformsubmitE[0].number = this.DE_numbere*/
            this.DEformsubmitE[0].company = (this.DE_customere2 != "" && this.DE_customere2 != null ? this.DE_customere2 : this.DE_customere.comname)
            this.DEformsubmitE[0].height = String(this.DE_heighte)
            this.DEformsubmitE[0].weight = String(this.DE_weighte)
            this.DEformsubmitE[0].bloodgr = this.DE_bloodgre
            this.DEformsubmitE[0].pulse = this.DE_pulsee
            this.DEformsubmitE[0].bloodpr = this.DE_bpme + "/" + this.DE_bpe
            this.DEformsubmitE[0].hissick = this.DE_hissicke
            this.DEformsubmitE[0].hisphara = this.DE_hispharae
            this.DEformsubmitE[0].cigar = this.DE_cigare
            this.DEformsubmitE[0].alcohol = this.DE_alcohole
            this.DEformsubmitE[0].sodium = this.DE_sodiume
            this.DEformsubmitE[0].potassium = this.DE_potassiume
            this.DEformsubmitE[0].chloride = this.DE_chloridee
            this.DEformsubmitE[0].totalc02 = this.DE_totalco2e
            this.DEformsubmitE[0].uricacid = this.DE_uricacide
            this.DEformsubmitE[0].bun = this.DE_bune
            this.DEformsubmitE[0].creatinine = this.DE_creatininee
            this.DEformsubmitE[0].choiesterol = this.DE_choiesterole
            this.DEformsubmitE[0].triglyceride = this.DE_triglyceridee
            this.DEformsubmitE[0].hdlc = this.DE_hdlce
            this.DEformsubmitE[0].ldlc = this.DE_ldlce
            this.DEformsubmitE[0].totalpro = this.DE_totalproteine
            this.DEformsubmitE[0].albumin = this.DE_albumine
            this.DEformsubmitE[0].globulin = this.DE_globuline
            this.DEformsubmitE[0].fbs = this.DE_fbse
            this.DEformsubmitE[0].amphetamine = this.DE_amphetaminee
            this.DEformsubmitE[0].pregnancy = this.DE_pregnancye
            this.DEformsubmitE[0].hbsag = this.DE_hbsage
            this.DEformsubmitE[0].hbsagb = this.DE_hbsagbe
            this.DEformsubmitE[0].antihavtotal = this.DE_antihavtotale
            this.DEformsubmitE[0].antihavigm = this.DE_antihavigme
            this.DEformsubmitE[0].vdrl = this.DE_vdrle
            this.DEformsubmitE[0].antihiv = this.DE_antihive
            this.DEformsubmitE[0].tsh = this.DE_tshe
            this.DEformsubmitE[0].freet3 = this.DE_freet3e
            this.DEformsubmitE[0].freet4 = this.DE_freet4e
            this.DEformsubmitE[0].t3 = this.DE_t3e
            this.DEformsubmitE[0].t4 = this.DE_t4e
            this.DEformsubmitE[0].hemoglobin = this.DE_hemoglobine
            this.DEformsubmitE[0].hematocrit = this.DE_hematocrite
            this.DEformsubmitE[0].wbc = this.DE_wbce
            this.DEformsubmitE[0].lym = this.DE_lyme
            this.DEformsubmitE[0].gran = this.DE_grane
            this.DEformsubmitE[0].mid = this.DE_mide
            this.DEformsubmitE[0].platelet = this.DE_platelete
            this.DEformsubmitE[0].mcv =  this.DE_mcv
            this.DEformsubmitE[0].mch =  this.DE_mch
            this.DEformsubmitE[0].mchc =  this.DE_mchc
            this.DEformsubmitE[0].eyecolor = this.DE_eyecolore
            this.DEformsubmitE[0].xray = this.DE_xraye
            this.DEformsubmitE[0].s1 = this.DE_s1e
            this.DEformsubmitE[0].s2 = this.DE_s2e
            this.DEformsubmitE[0].s3 = this.DE_s3e
            this.DEformsubmitE[0].s4 = this.DE_s4e
            this.DEformsubmitE[0].s5 = this.DE_s5e
            this.DEformsubmitE[0].s6 = this.DE_s6e
            this.DEformsubmitE[0].s7 = this.DE_s7e
            this.DEformsubmitE[0].s8 = this.DE_s8e
            this.DEformsubmitE[0].alk = this.DE_alke
            this.DEformsubmitE[0].totalbilirubin = this.DE_totalbilirubine
            this.DEformsubmitE[0].direct = this.DE_directe
            this.DEformsubmitE[0].sgot = this.DE_sgote
            this.DEformsubmitE[0].sgpt = this.DE_sgpte
            this.DEformsubmitE[0].color = this.DE_colore
            this.DEformsubmitE[0].ph = this.DE_phe
            this.DEformsubmitE[0].protien = this.DE_protiene
            this.DEformsubmitE[0].sg = this.DE_sg
            this.DEformsubmitE[0].glucose = this.DE_glucosee
            this.DEformsubmitE[0].ketone = this.DE_ketonee
            this.DEformsubmitE[0].bilirubin = this.DE_bilirubine
            this.DEformsubmitE[0].urobilinogen = this.DE_urobilinogene
            this.DEformsubmitE[0].blood = this.DE_bloode
            this.DEformsubmitE[0].leukocyte = this.DE_leukocytee
            this.DEformsubmitE[0].nitrite = this.DE_nitritee
            this.DEformsubmitE[0].urin1 = this.DE_urin1e
            this.DEformsubmitE[0].urin2 = this.DE_urin2e
            this.DEformsubmitE[0].stoolex = this.DE_stoolexe
            this.DEformsubmitE[0].stoolcul = this.DE_stoolcule
            this.DEformsubmitE[0].hissickbody = this.DE_hissickbodye
            this.DEformsubmitE[0].hisfood = this.DE_hisfoode
            this.DEformsubmitE[0].hissickwork = this.DE_hissickworke
            this.DEformsubmitE[0].labinves = this.DE_labinvese
            /*this.DEformsubmitE[0].wbcdif = this.DE_wbcdif*/
            this.DEformsubmitE[0].ascorbic = this.DE_ascorbice
            
            this.DEformsubmitE[0].diff4 = this.DE_dif4e
            this.DEformsubmitE[0].diff5 = this.DE_dif5e
            this.DEformsubmitE[0].clarity = this.DE_claritye
            this.DEformsubmitE[0].stoolex = this.DE_stoolexe
            this.DEformsubmitE[0].stoolcul = this.DE_stoolcue
            this.DEformsubmitE[0].id = this.iddetaile
            this.DEformsubmitE[0].medtype = this.medtypewalk

             console.log(this.DEformsubmitE)
           
            axios({
                method: 'post',
                url: '/patient/savedatadeedit',
                data: this.DEformsubmitE
            })
                .then(res => {
                    console.log(res)

                    if (res.data == "suc") {
                        alert("บันทึกข้อมูลสำเร็จ")
                        /*  $("#staticBackdrop").hide();*/
                        this.getdatadet(this.DE_number)
                        this.chkselectpatient = 0
                    } else {
                        alert(res)
                    }                   /* this.company = res.data*/
                })
                .catch(err => {
                    console.log(err);
                })
        },
        editpatient(id) {

            this.formsubmitE[0].fname = this.fnamee
            this.formsubmitE[0].lname = this.lnamee
            this.formsubmitE[0].adr = this.adre
            this.formsubmitE[0].idcard = this.idcarde
            this.formsubmitE[0].idpart = this.idparte
            this.formsubmitE[0].tanon = this.tanone
            this.formsubmitE[0].tambon = this.tambone
            this.formsubmitE[0].ampur = this.ampure
            this.formsubmitE[0].province = this.provincee
            this.formsubmitE[0].postcode = this.postcodee
            this.formsubmitE[0].career = this.careere
            this.formsubmitE[0].tel = this.tele
            this.formsubmitE[0].gender = this.gendere
            this.formsubmitE[0].titlen = this.titlene
            this.formsubmitE[0].birthday = this.birthdaye
            this.formsubmitE[0].idpat = this.idpate
            this.formsubmitE[0].idrun = this.idrune
            this.formsubmitE[0].id = id



           /*  console.log(this.formsubmitE)*/
            /* console.log(this.formsubmit[0].fname)*/
            axios({
                method: 'post',
                url: '/patient/updatedata',
                data: this.formsubmitE
            })
                .then(res => {
                   
                    if (res.data == "suc") {
                       
                        alert("บันทึกข้อมูลสำเร็จ")
                        this.getpatient()
                       /* $("#edit").modal("hide");*/
                       
                    } else {
                        alert("บันทึกข้อมูลไม่สำเร็จ !!!")
                    }
                    
                })
                .catch(err => {
                    console.log(err);
                })
        },
        setdis() {
            alert(this.disabled)
            if (this.disabled == 0)
                this.disabled = 1
            else
                this.disabled = 0

        },
        getdatadig(id) {
            this.disabled = 0
            axios.get("/Patient/Getdatadig",
                {
                    params: {
                        id: id

                    }
                })
                .then(res => {
                   
                    /* console.log(res.data);*/
                    /* this.getdatadetail = res.data*/
                    this.cncodee = "BB-" + res.data[0].idPatient + (res.data[0].iDrunnumber > 9 ? "-00" : (res.data[0].iDrunnumber > 99 ? "-0" : (res.data[0].iDrunnumber >= 999 ? "-" : "-000"))) + res.data[0].iDrunnumber;
                    this.titlene = res.data[0].titlename;
                    this.fnamee = res.data[0].fname;
                    this.lnamee = res.data[0].lname;
                    this.gendere = (res.data[0].gender == "ชาย" ? 1 : 2);
                    this.idcarde = res.data[0].idCard;
                    this.idparte = res.data[0].idpart;
                    this.adre = res.data[0].address;
                    this.tanone = res.data[0].titlename;
                    this.tambone = res.data[0].subDistrict;
                    this.ampure = res.data[0].district;
                    this.provincee = res.data[0].province;
                    this.postcodee = res.data[0].postcode;
                    this.careere = res.data[0].career;
                    this.tele = res.data[0].tel;
                    this.birthdaye = res.data[0].birthday;
                    this.idpae = res.data[0].id;
                    //this.idrune = res.data.titlename;


                    this.getdis(2)
                    this.getsubdis(2)
                    this.getAge(2)
                   
                    /*console.log(res.data)*/
                }).catch(err => {
                    console.log(err);
                })

        },
        setcheckhis(id) {
            this.CheckHis = id
            this.getdatadig(this.CheckHis)
        },
        printmedreport(id) {

            /* alert(id)*/
            window.open(window.location.origin + "/Patient/GetPrintmed?id=" + id, "'_blank'");

        }, printcertreport(id) {

            /* alert(id)*/
            window.open(window.location.origin + "/medic/GetPrintcertificate?id=" + id, "'_blank'");

        }, printcertreportfor(id) {

            /* alert(id)*/
            window.open(window.location.origin + "/medic/GetPrintcertificatefor?id=" + id, "'_blank'");

        },
        printmedreciept(id) {

            /* alert(id)*/
            window.open(window.location.origin + "/Patient/GetPrintreciept?id=" + id, "'_blank'");

        },
        getdatadet(id) {
          
            axios.get("/Patient/Getdatadetail",
                {
                    params: {
                        id: id

                    }
                })
                .then(res => {
                    console.log(res.data);

                    for (i = 0; i < res.data.length; i++) {
                        this.chkselpayment[i] = res.data[i].x.urin2
                        this.idpayment[i] = res.data[i].x.alk
                       /* console.log(this.chkselpayment[i])*/
                    }
                    
                    this.getdatadetail = res.data
                    console.log(this.chkselpayment)
                }).catch(err => {
                    console.log(err);
                })
           
        },
        Createdetail() {
            $("#staticBackdrop").show();
        
            this.DEformsubmitE[0].number = this.DE_number
            this.DEformsubmitE[0].date = this.DE_datee
            this.DEformsubmitE[0].time = this.DE_timee
            /*this.DEformsubmitE[0].number = this.DE_numbere*/
            this.DEformsubmitE[0].company = (this.DE_customere2 != "" && this.DE_customere2 != null && this.DE_customere2 != "-"? this.DE_customere2 : this.DE_customere.comname)
            this.DEformsubmitE[0].height = String(this.DE_heighte)
            this.DEformsubmitE[0].weight = String(this.DE_weighte)
            this.DEformsubmitE[0].bloodgr = (this.DE_bloodgre == "null" ? "" : this.DE_bloodgre)
            this.DEformsubmitE[0].pulse = this.DE_pulsee
            this.DEformsubmitE[0].bloodpr = this.DE_bpme + "/" + this.DE_bpe
            this.DEformsubmitE[0].hissick = this.DE_hissicke
            this.DEformsubmitE[0].hisphara = this.DE_hispharae
            this.DEformsubmitE[0].cigar = this.DE_cigare
            this.DEformsubmitE[0].alcohol = this.DE_alcohole
            this.DEformsubmitE[0].sodium = this.DE_sodiume
            this.DEformsubmitE[0].potassium = this.DE_potassiume
            this.DEformsubmitE[0].chloride = this.DE_chloridee
            this.DEformsubmitE[0].totalc02 = this.DE_totalco2e
            this.DEformsubmitE[0].uricacid = this.DE_uricacide
            this.DEformsubmitE[0].bun = this.DE_bune
            this.DEformsubmitE[0].creatinine = this.DE_creatininee
            this.DEformsubmitE[0].choiesterol = this.DE_choiesterole
            this.DEformsubmitE[0].triglyceride = this.DE_triglyceridee
            this.DEformsubmitE[0].hdlc = this.DE_hdlce
            this.DEformsubmitE[0].ldlc = this.DE_ldlce
            this.DEformsubmitE[0].totalpro = this.DE_totalproteine
            this.DEformsubmitE[0].albumin = this.DE_albumine
            this.DEformsubmitE[0].globulin = this.DE_globuline
            this.DEformsubmitE[0].fbs = this.DE_fbse
            this.DEformsubmitE[0].amphetamine = this.DE_amphetaminee
            this.DEformsubmitE[0].pregnancy = this.DE_pregnancye
            this.DEformsubmitE[0].hbsag = this.DE_hbsage
            this.DEformsubmitE[0].hbsagb = this.DE_hbsagbe
            this.DEformsubmitE[0].antihavtotal = this.DE_antihavtotale
            this.DEformsubmitE[0].antihavigm = this.DE_antihavigme
            this.DEformsubmitE[0].vdrl = this.DE_vdrle
            this.DEformsubmitE[0].antihiv = this.DE_antihive
            this.DEformsubmitE[0].tsh = this.DE_tshe
            this.DEformsubmitE[0].freet3 = this.DE_freet3e
            this.DEformsubmitE[0].freet4 = this.DE_freet4e
            this.DEformsubmitE[0].t3 = this.DE_t3e
            this.DEformsubmitE[0].t4 = this.DE_t4e
            this.DEformsubmitE[0].hemoglobin = this.DE_hemoglobine
            this.DEformsubmitE[0].hematocrit = this.DE_hematocrite
            this.DEformsubmitE[0].wbc = this.DE_wbce
            this.DEformsubmitE[0].lym = this.DE_lyme
            this.DEformsubmitE[0].gran = this.DE_grane
            this.DEformsubmitE[0].mid = this.DE_mide
            this.DEformsubmitE[0].platelet = this.DE_platelete
            this.DEformsubmitE[0].mcv = this.DE_mcv
            this.DEformsubmitE[0].mch = this.DE_mch
            this.DEformsubmitE[0].mchc = this.DE_mchc
            this.DEformsubmitE[0].eyecolor = this.DE_eyecolore
            this.DEformsubmitE[0].xray = this.DE_xraye
            this.DEformsubmitE[0].s1 = this.DE_s1e
            this.DEformsubmitE[0].s2 = this.DE_s2e
            this.DEformsubmitE[0].s3 = this.DE_s3e
            this.DEformsubmitE[0].s4 = this.DE_s4e
            this.DEformsubmitE[0].s5 = this.DE_s5e
            this.DEformsubmitE[0].s6 = this.DE_s6e
            this.DEformsubmitE[0].s7 = this.DE_s7e
            this.DEformsubmitE[0].s8 = this.DE_s8e
            this.DEformsubmitE[0].alk = this.DE_alke
            this.DEformsubmitE[0].totalbilirubin = this.DE_totalbilirubine
            this.DEformsubmitE[0].direct = this.DE_directe
            this.DEformsubmitE[0].sgot = this.DE_sgote
            this.DEformsubmitE[0].sgpt = this.DE_sgpte
            this.DEformsubmitE[0].color = this.DE_colore
            this.DEformsubmitE[0].ph = this.DE_phe
            this.DEformsubmitE[0].protien = this.DE_protiene
            this.DEformsubmitE[0].sg = this.DE_sg
            this.DEformsubmitE[0].glucose = this.DE_glucosee
            this.DEformsubmitE[0].ketone = this.DE_ketonee
            this.DEformsubmitE[0].bilirubin = this.DE_bilirubine
            this.DEformsubmitE[0].urobilinogen = this.DE_urobilinogene
            this.DEformsubmitE[0].blood = this.DE_bloode
            this.DEformsubmitE[0].leukocyte = this.DE_leukocytee
            this.DEformsubmitE[0].nitrite = this.DE_nitritee
            this.DEformsubmitE[0].urin1 = this.DE_urin1e
            this.DEformsubmitE[0].urin2 = this.DE_urin2e
            this.DEformsubmitE[0].stoolex = this.DE_stoolexe
            this.DEformsubmitE[0].stoolcul = this.DE_stoolcule
            this.DEformsubmitE[0].hissickbody = this.DE_hissickbodye
            this.DEformsubmitE[0].hisfood = this.DE_hisfoode
            this.DEformsubmitE[0].hissickwork = this.DE_hissickworke
            this.DEformsubmitE[0].labinves = this.DE_labinvese
            /*this.DEformsubmitE[0].wbcdif = this.DE_wbcdif*/
            this.DEformsubmitE[0].ascorbic = this.DE_ascorbice

            this.DEformsubmitE[0].diff4 = this.DE_dif4e
            this.DEformsubmitE[0].diff5 = this.DE_dif5e
            this.DEformsubmitE[0].clarity = this.DE_dif5e
            this.DEformsubmitE[0].stoolex = this.DE_stoolexe
            this.DEformsubmitE[0].stoolcul = this.DE_stoolcue
            if (this.iddetaile != "" && this.iddetaile != null)
                this.DEformsubmitE[0].id = this.iddetaile
            this.DEformsubmitE[0].medtype = this.medtypewalk

            console.log(this.DEformsubmitE)

            axios({
                method: 'post',
                url: '/patient/savedatadetail',
                data: this.DEformsubmitE
            })
                .then(res => {
                   /* console.log(res)*/

                    if (res.data == "suc") {
                        alert("บันทึกข้อมูลสำเร็จ")
                        $("#staticBackdrop").hide();
                        this.getdatadet(this.DE_number)
                        this.chkselectpatient = 0
                    } else {
                        alert(res)
                    }                   /* this.company = res.data*/
                })
                .catch(err => {
                    console.log(err);
                })

        },
        Createpatient() {
            $("#staticBackdrop").show();

            this.formsubmit[0].fname = this.fname
            this.formsubmit[0].lname = this.lname
            this.formsubmit[0].adr = this.adr
            this.formsubmit[0].idcard = this.idcard
            this.formsubmit[0].idpart = this.idpart
           /* this.formsubmit[0].tanon = this.tanon*/
            this.formsubmit[0].tambon = this.tambon
            this.formsubmit[0].ampur = this.ampur
            this.formsubmit[0].province = this.province
            this.formsubmit[0].postcode = this.postcode
            this.formsubmit[0].career = this.career
            this.formsubmit[0].tel = this.tel
            this.formsubmit[0].gender = parseInt(this.gender)
            this.formsubmit[0].titlen = this.titlen
            this.formsubmit[0].birthday = this.birthday
            this.formsubmit[0].idpat = this.idpat
            this.formsubmit[0].idrun = this.idrun

          
            console.log(this.formsubmit)
            /* console.log(this.formsubmit[0].fname)*/
            axios({
                method: 'post',
                url: '/patient/savedata',
                data: this.formsubmit
            })
                .then(res => {
                    if (res.data == "suc") {

                        alert("บันทึกข้อมูลสำเร็จ")
                        this.getpatient()
                        $("#staticBackdrop").hide();
                    } else {
                        alert("บันทึกข้อมูลไม่สำเร็จ !!!")
                    }

                   
                })
                .catch(err => {
                    console.log(err);
                })
                

        },
        Createsel() {
            $("#staticBackdrop").show();

            /*this.formsubmitsel[0].medser = this.medtypesel*/
            this.formsubmitsel[0].paymenty = this.paymentsel
            this.formsubmitsel[0].totalprice = this.prisel
            this.formsubmitsel[0].moneyre = this.moneyresel
            this.formsubmitsel[0].remark = this.remarksel
            this.formsubmitsel[0].repaydat = this.repaydatesel
            this.formsubmitsel[0].deducsaldat = this.rededatesel
            this.formsubmitsel[0].recommen = this.reccomsel
            this.formsubmitsel[0].id = this.idsel
            this.formsubmitsel[0].company = this.customersel
          /*  this.formsubmitsel[0].prid = this.province*/
           


            console.log(this.formsubmitsel)
            /* console.log(this.formsubmit[0].fname)*/
            axios({
                method: 'post',
                url: '/patient/savedatasel',
                data: this.formsubmitsel
            })
                .then(res => {
                    console.log(res)

                    //console.log(res.data);
                    ageString = "Oops! ต้องการยืนยันการบันทึกข้อมูล!";
                    alert(ageString)
                    //---show already has data

                    if (res.data == "suc") {
                        alert("บันทึกข้อมูลสำเร็จ")
                        /*  $("#staticBackdrop").hide();*/
                        this.getdatadet(this.DE_number)

                        this.cnsel = [];
                        this.mednosel = [];
                        this.fnamesel = []
                        this.lnamesel = []
                        this.titlesel = []
                        this.customersel = []
                        this.idsel = []
                        this.prisel = []
                        this.medtypesel = []
                        this.paymentsel = []
                        this.moneyresel = []
                        this.reccomsel = []



                        $("#staticBackdrop").hide();
                    } else {
                        alert(res)
                    }
                    this.getpatient()

                })
                .catch(err => {
                    console.log(err);

                    //console.log(res.data);
                    if (res.data.cncode == "") { 
                    ageString = "Oops! ยังไม่ได้ขอรหัส CN จากระบบ!";
                    alert(ageString)
                    }else{
                    //---show already has data
                        ageString = "Oops! ยังไม่ได้ขอรหัส CN จากระบบ!";
                        alert(ageString)
                     }

                })


        },
        editsel() {


            /*this.formsubmitsel[0].medser = this.medtypesel*/
            this.formsubmitsel[0].paymenty = this.paymentsel
            this.formsubmitsel[0].totalprice = this.prisel
            this.formsubmitsel[0].moneyre = this.moneyresel
            this.formsubmitsel[0].remark = this.remarksel
            this.formsubmitsel[0].repaydat = this.repaydatesel
            this.formsubmitsel[0].deducsaldat = this.rededatesel
            this.formsubmitsel[0].recommen = this.reccomsel
            this.formsubmitsel[0].id = this.idsel
            this.formsubmitsel[0].company = this.customersel
            /*  this.formsubmitsel[0].prid = this.province*/


           /* alert(this.reccomsel)*/
            console.log(this.formsubmitsel)
            /* console.log(this.formsubmit[0].fname)*/
            axios({
                method: 'post',
                url: '/patient/editdatasel',
                data: this.formsubmitsel
            })
                .then(res => {
                    console.log(res)
                    if (res.data == "suc") {
                        alert("บันทึกข้อมูลสำเร็จ")
                        /*  $("#staticBackdrop").hide();*/
                        this.getdatadet(this.DE_number)
                    } else {
                        alert(res)
                    }
                    this.getpatient()
                })
                .catch(err => {
                    console.log(err);
                })


        },
        statussel() {


            /*this.formsubmitsel[0].medser = this.medtypesel*/
            this.formsubmitsel[0].paymenty = this.paymentsel
            this.formsubmitsel[0].totalprice = this.prisel
            this.formsubmitsel[0].moneyre = this.moneyresel
            this.formsubmitsel[0].remark = this.remarksel
            this.formsubmitsel[0].repaydat = this.repaydatesel
            this.formsubmitsel[0].deducsaldat = this.rededatesel
            this.formsubmitsel[0].recommen = this.reccomsel
            this.formsubmitsel[0].id = this.idsel
            this.formsubmitsel[0].company = this.customersel
            /*  this.formsubmitsel[0].prid = this.province*/


            /* alert(this.reccomsel)*/
            console.log(this.formsubmitsel)
            /* console.log(this.formsubmit[0].fname)*/
            axios({
                method: 'post',
                url: '/patient/editdatasel',
                data: this.formsubmitsel
            })
                .then(res => {
                    console.log(res)
                    if (res.data == "suc") {
                        alert("บันทึกข้อมูลสำเร็จ")
                        /*  $("#staticBackdrop").hide();*/
                        this.getdatadet(this.DE_number)
                    } else {
                        alert(res)
                    }
                    this.getpatient()
                })
                .catch(err => {
                    console.log(err);
                })


        }, getdataCNcheck() {

            axios.get("/Patient/GetdataCN", {
                params: {
                    id: (this.idcard != "" && this.idcard != null ? this.idcard : this.idpart),

                }
            })
                .then(res => {



                    try {
                        var a = res.data.split("/");
                        this.cncode = "BB-" + a[0] + (a[1] > 9 ? "-00" : (a[1] > 99 ? "-0" : (a[1] >= 999 ? "-" : "-000"))) + parseInt(a[1])
                        this.idpat = a[0]
                        this.idrun = a[1]

                        this.adr = ""
                        this.fname = ""
                        this.lname = ""
                        this.titlen = ""
                        this.gender = ""
                        this.tanon = ""
                        this.province = ""
                        this.ampur = ""
                        this.tambon = ""
                        this.postcode = ""
                        this.tel = ""
                        this.career = ""
                        this.birthday = ""

                        this.yearV = ""
                        this.monthV = ""
                        this.dayV = ""
                        this.age = ""

                        this.getdis()
                        this.getsubdis()

                        this.chkdupil = false
                        /*  console.log(res.address)*/


                    } catch {
                        console.log(res.data);
                        this.adr = res.data.address
                        this.fname = res.data.fname
                        this.lname = res.data.lname
                        this.titlen = res.data.titlename
                        this.gender = (res.data.gender == "ชาย" ? 1 : 2)
                        this.tanon = res.data.address
                        this.province = res.data.province
                        this.ampur = res.data.district
                        this.tambon = res.data.subDistrict
                        this.postcode = res.data.postcode
                        this.tel = res.data.tel
                        this.career = res.data.career
                        this.birthday = res.data.birthday
                        this.cncode = "BB-" + res.data.idPatient + (res.data.iDrunnumber > 9 ? "-00" : (res.data.iDrunnumber > 99 ? "-0" : (res.data.iDrunnumber >= 999 ? "-" : "-000"))) + res.data.iDrunnumber


                        this.getdis()
                        this.getsubdis()
                        this.getAge()

                        this.chkdupil = true
                    }



                }).catch(err => {
                    console.log(err);
                })


        },
        getdataCN() {

            axios.get("/Patient/GetdataCN", {
                params: {
                    id: (this.idcard != "" && this.idcard != null ? this.idcard : this.idpart),

                }
            })
                .then(res => {

                    try {
                        var a = res.data.split("/");

                        //check cn id in case dupplicate
                        //this.cncode = "BB-" + a[0] + (a[1] > 9 ? "-00" : (a[1] > 99 ? "-0" : (a[1] >= 999 ? "-" : "-000"))) + parseInt(a[1])
                        if (this.cncode != "") { this.cncode = "BB-" + a[0] + (a[1] > 9 ? "-00" : (a[1] > 99 ? "-0" : (a[1] >= 999 ? "-" : "-000"))) + parseInt(a[1]) + 1 } else { this.cncode = "BB-" + a[0] + (a[1] > 9 ? "-00" : (a[1] > 99 ? "-0" : (a[1] >= 999 ? "-" : "-000"))) + parseInt(a[1]) }

                        this.idpat = a[0]
                        this.idrun = a[1]

                        this.adr = ""
                        this.fname = ""
                        this.lname = ""
                        this.titlen = ""
                        this.gender = ""
                        this.tanon = ""
                        this.province = ""
                        this.ampur = ""
                        this.tambon = ""
                        this.postcode = ""
                        this.tel = ""
                        this.career = ""
                        this.birthday = ""
                       
                        this.yearV = ""
                        this.monthV = ""
                        this.dayV = ""
                        this.age = ""

                        this.getdis()
                        this.getsubdis()

                        //stand by for save data
                        this.chkdupil = false

                        /*  console.log(res.address)*/


                    } catch {
                        console.log(res.data);

                        //console.log(res.data);
                        if (this.idcard == "" ) {
                            ageString = "Oops! ใส่รหัสบัตรประจำตัวประชาชน!";
                            alert(ageString)
                        } else {
                            //---show already has data
                            //ageString = "Oops! ยังไม่ได้ขอรหัส CN จากระบบ!";
                            //alert(ageString)
                        //}


                        ageString = "Oops! เคยลงทะเบียนเรียบร้อย!";
                        alert(ageString)

                            //---show already has data
                        this.idcardCus = res.data.idcardCus
                        this.adr = res.data.address
                        this.fname = res.data.fname
                        this.lname = res.data.lname
                        this.titlen = res.data.titlename
                        this.gender = (res.data.gender == "ชาย" ? 1 : 2)
                        this.DateCus = res.data.DateCus //date of birth
                        this.weightCus = res.data.weightCus
                        this.tanon = res.data.address
                        this.province = res.data.province
                        this.ampur = res.data.district
                        this.tambon = res.data.subDistrict
                        this.postcode = res.data.postcode
                        this.tel = res.data.tel
                        this.career = res.data.career
                        this.birthday = res.data.birthday
                        this.cncode = "BB-" + res.data.idPatient + (res.data.iDrunnumber > 9 ? "-00" : (res.data.iDrunnumber > 99 ? "-0" : (res.data.iDrunnumber >= 999 ? "-" : "-000"))) + res.data.iDrunnumber
                        
                        this.getdis()
                        this.getsubdis()
                        this.getAge()

                        //control save button
                        this.chkdupil = true 

                       }//end for get data

                    }



                }).catch(err => {
                    console.log(err);

                    //check cn id in case dupplicate
                    //this.cncode = "BB-" + a[0] + (a[1] > 9 ? "-00" : (a[1] > 99 ? "-0" : (a[1] >= 999 ? "-" : "-000"))) + parseInt(a[1])
                    this.idcard = ""

                    if (this.cncode != "") { this.cncode = "BB-" + a[0] + (a[1] > 9 ? "-00" : (a[1] > 99 ? "-0" : (a[1] >= 999 ? "-" : "-000"))) + parseInt(a[1]) + 1 } else { this.cncode = "BB-" + a[0] + (a[1] > 9 ? "-00" : (a[1] > 99 ? "-0" : (a[1] >= 999 ? "-" : "-000"))) + parseInt(a[1]) }

                })


        },
        getAge(ch) {
            /*  alert(this.birthday)*/
            /*alert("a")*/
            var now = new Date();
            var today = new Date(now.getYear(), now.getMonth(), now.getDate());

            var yearNow = now.getYear();
            var monthNow = now.getMonth();
            var dateNow = now.getDate();

            var dob = new Date((ch == 2 ? this.birthdaye : this.birthday));

            /*alert(dob)*/
            var yearDob = dob.getYear();
            var monthDob = dob.getMonth();
            var dateDob = dob.getDate();
            var age = {};
            var ageString = "";
            var yearString = "";
            var monthString = "";
            var dayString = "";


            yearAge = yearNow - yearDob;

            if (monthNow >= monthDob)
                var monthAge = monthNow - monthDob;
            else {
                yearAge--;
                var monthAge = 12 + monthNow - monthDob;
            }

            if (dateNow >= dateDob)
                var dateAge = dateNow - dateDob;
            else {
                monthAge--;
                var dateAge = 31 + dateNow - dateDob;

                if (monthAge < 0) {
                    monthAge = 11;
                    yearAge--;
                }
            }

            age = {
                years: yearAge,
                months: monthAge,
                days: dateAge
            };

            if (age.years > 1) yearString = " years";
            else yearString = " year";
            if (age.months > 1) monthString = " months";
            else monthString = " month";
            if (age.days > 1) dayString = " days";
            else dayString = " day";

            this.yearV = age.years
            this.monthV = age.months
            this.dayV = age.days
            this.age = age.years

            if (ch == 2) {

                this.yearVe = age.years
                this.monthVe = age.months
                this.dayVe = age.days
                this.agee = age.years
            }
           
            if ((age.years > 0) && (age.months > 0) && (age.days > 0))
                ageString = age.years + yearString + ", " + age.months + monthString + ", and " + age.days + dayString + " old.";
            else if ((age.years == 0) && (age.months == 0) && (age.days > 0))
                ageString = "Only " + age.days + dayString + " old!";
            else if ((age.years > 0) && (age.months == 0) && (age.days == 0))
                ageString = age.years + yearString + " old. Happy Birthday!!";
            else if ((age.years > 0) && (age.months > 0) && (age.days == 0))
                ageString = age.years + yearString + " and " + age.months + monthString + " old.";
            else if ((age.years == 0) && (age.months > 0) && (age.days > 0))
                ageString = age.months + monthString + " and " + age.days + dayString + " old.";
            else if ((age.years > 0) && (age.months == 0) && (age.days > 0))
                ageString = age.years + yearString + " and " + age.days + dayString + " old.";
            else if ((age.years == 0) && (age.months > 0) && (age.days == 0))
                ageString = age.months + monthString + " old.";
            else ageString = "Oops! Could not calculate age!";
           /* alert(ageString)*/
            /*return ageString;*/

        },
        getdis(ch) {

            axios.get("/Patient/GetDistrict", {
                params: {
                    id: (ch == 2 ? this.provincee : this.province),

                }
            })
                .then(res => {
                    this.getdistrict = res.data
                   
                }).catch(err => {
                    console.log(err);
                })



           

        },
        getsubdis(ch) {

            axios.get("/Patient/GetSubDistrict", {
                params: {
                    id: (ch == 2 ? this.ampure : this.ampur),

                }
            })
                .then(res => {
                    this.getsubdistrict = res.data

                }).catch(err => {
                    console.log(err);
                })


            axios.get("/Patient/GetPostcode", {
                params: {
                    id: (ch == 2 ? this.ampure : this.ampur),

                }
            })
                .then(res => {
                    console.log(res.data);
                    this.getpostcode = res.data

                }).catch(err => {
                    console.log(err);
                })
        }

        , getpatient() {
            axios.get("/Patient/Getdatapatient")
                .then(res => {
                    /* console.log(res.data);*/
                    this.getdatapatirnt = res.data

                }).catch(err => {
                    console.log(err);
                })
        }

        , getdatamedtype() {
            axios.get("/Patient/Getdatamedt")
                .then(res => {
                    /* console.log(res.data);*/
                    this.getdatamedty = res.data

                }).catch(err => {
                    console.log(err);
                })

        }
        , getdatapaytype() {
            
            axios.get("/Patient/Getdatapayt")
                .then(res => {
                    /* console.log(res.data);*/
                    this.getdatapayty = res.data

                }).catch(err => {
                    console.log(err);
                })

        }
        , getdatareceive() {
            axios.get("/Patient/Getdataret")
                .then(res => {
                    /* console.log(res.data);*/
                    this.getdatareciveper = res.data

                }).catch(err => {
                    console.log(err);
                })

        }
        , getdatacom() {
            axios.get("/Patient/Getdatacom")
                .then(res => {
                    /* console.log(res.data);*/
                    this.getdatacompany = res.data

                }).catch(err => {
                    console.log(err);
                })

        }
        , chkgender() {
            if (this.titlen == 'นาย' || this.titlen == 'Mr.') {
                this.gender = 1

            } else {
                this.gender = 2
            }

        }
        , setsummary() {
            if (this.DE_amphetaminee == "Negative")
                this.DE_s4e = "1"
            else if (this.DE_amphetaminee == "Positive")
                this.DE_s4e = "2"
            else
                this.DE_s4e = "0"


            if (this.DE_pregnancye == "Negative")
                this.DE_s5e = "1"
            else if (this.DE_pregnancye == "Positive")
                this.DE_s5e = "2"
            else
                this.DE_s5e = "0"


            if (this.DE_hbsage == "Negative")
                this.DE_s6e = "1"
            else if (this.DE_hbsage == "Positive")
                this.DE_s6e = "2"
            else
                this.DE_s6e = "0"

            if (this.DE_antihive == "Negative")
                this.DE_s8e = "1"
            else if (this.DE_antihive == "Positive")
                this.DE_s8e = "2"
            else
                this.DE_s8e = "0"
            

        }
        , checid() {
          
            if (this.refnosel == "")
                alert("กรุณาระบุผู้เข้ารับการตรวจสุขภาพ")



        }
        , chekpatient() {

            this.chkselectpatient


        }
        , getdatachktype() {
            
            axios.get("/Patient/Gettypechk", {
                params: {
                    id: this.DE_customere.code
                }
            })
                .then(res => {
                    /* console.log(res.data);*/
                    this.getdatachkty = res.data
                    /*console.log(this.getdatachkty)*/

                }).catch(err => {
                    console.log(err);
                })
            
        }
        , getdatareca() {

            axios.get("/Patient/Gettyperec")
                .then(res => {
                    /* console.log(res.data);*/
                    this.getdatarec = res.data
                    /*console.log(this.getdatachkty)*/

                }).catch(err => {
                    console.log(err);
                })

        }
        , toggledel(id) {


            if (confirm("ต้องการลบคนไข้ใช่ไหม") == true) {
                const formdata = new FormData();
                formdata.append('ID', id);
              /*  formdata.append('Status', str);*/
                axios.post("/patient/deldatapatient", formdata)
                    .then(res => {
                        this.getpatient()
                        if (res.data == "success") {
                            alert("Success")
                            //$("#_account_detail").modal("hide");
                            //this.account = [];
                            this.getpatient()
                        }

                    })
                    .catch(err => {
                        console.log(err);
                    });
            }
        }
        ,
        Createmed3() {
            $("#staticBackdrop").show();
            this.formmed[0].DateCus = this.DateCusmd
          
            this.formmed[0].fname = this.fnamemd
            this.formmed[0].lname = this.lnamemd
            this.formmed[0].adr = this.adrmd
            this.formmed[0].idcard = this.idcardmd
           
            this.formmed[0].tex5 = this.tex5md
            this.formmed[0].ch6 = this.ch6md
            this.formmed[0].tex6 = this.tex6md
            
            this.formmed[0].comment = this.commentmd
            this.formmed[0].id = this.DE_number
            this.formmed[0].titlen = this.titlenmd
            this.formmed[0].medtype = "5"
            this.formmed[0].time = this.timemd
            this.formmed[0].type = this.typemedcer
            /*      console.log(this.comment)*/
            console.log(this.formmed)
            axios({
                method: 'post',
                url: '/medic/savedatatype3',
                data: this.formmed
            })
                .then(res => {
                    /*console.log(res)*/

                    if (res.data == "suc") {
                        alert("success")
                        $("#staticBackdrop").hide();
                        this.getdatadet(this.DE_number)
                    } else {
                        alert(res)
                    }                   /* this.company = res.data*/
                })
                .catch(err => {
                    console.log(err);
                })

        },
        Createmed2() {
            $("#staticBackdrop").show();
            this.formmed[0].fname = this.fnamemd
            this.formmed[0].lname = this.lnamemd
            this.formmed[0].adr = this.adrmd
            this.formmed[0].idcard = this.idcardmd
            this.formmed[0].ch1 = this.ch1md
            this.formmed[0].tex1 = this.tex1md
            this.formmed[0].ch2 = this.ch2md
            this.formmed[0].tex2 = this.tex2md
            this.formmed[0].ch3 = this.ch3md
            this.formmed[0].tex3 = this.tex3md
            this.formmed[0].ch4 = this.ch4md
            this.formmed[0].tex4 = this.tex4md
            this.formmed[0].tex5 = this.tex5md
            this.formmed[0].weight = String(this.weightmd)
            this.formmed[0].height = String(this.heightmd)
            this.formmed[0].blood = String(this.bloodmd)
            this.formmed[0].pulse = String(this.pulsemd)
            this.formmed[0].ch6 = this.ch6md
            this.formmed[0].tex6 = this.tex6md
            this.formmed[0].DateCus = this.DateCusmd
            this.formmed[0].titlen = this.titlenmd
            this.formmed[0].comment = this.commentmd
            this.formmed[0].id = this.DE_number
            this.formmed[0].medtype = "5"
            this.formmed[0].time = this.timemd
            this.formmed[0].type = this.typemedcer
            /*      console.log(this.comment)*/
            console.log(this.formmed)
            axios({
                method: 'post',
                url: '/medic/savedatatype2',
                data: this.formmed
            })
                .then(res => {
                    /*console.log(res)*/

                    if (res.data == "suc") {
                        alert("success")
                        $("#staticBackdrop").hide();
                        this.getdatadet(this.DE_number)
                    } else {
                        alert(res)
                    }                   /* this.company = res.data*/
                })
                .catch(err => {
                    console.log(err);
                })

        },
        Createmed1() {
            $("#staticBackdrop").show();
            this.formmed[0].fname = this.fnamemd
            this.formmed[0].lname = this.lnamemd
            this.formmed[0].adr = this.adrmd
            this.formmed[0].idcard = this.idcardmd
            this.formmed[0].ch1 = this.ch1md
            this.formmed[0].tex1 = this.tex1md
            this.formmed[0].ch2 = this.ch2md
            this.formmed[0].tex2 = this.tex2md
            this.formmed[0].ch3 = this.ch3md
            this.formmed[0].tex3 = this.tex3md
            
            this.formmed[0].tex5 = this.tex5md
            this.formmed[0].weight = String(this.weightmd)
            this.formmed[0].height = String(this.heightmd)
            this.formmed[0].blood = String(this.bloodmd)
            this.formmed[0].pulse = String(this.pulsemd)
            this.formmed[0].ch6 = this.ch6md
            this.formmed[0].tex6 = this.tex6md
            this.formmed[0].DateCus = this.DateCusmd
            this.formmed[0].titlen = this.titlenmd
            this.formmed[0].comment = this.commentmd
            this.formmed[0].id = this.DE_number
            this.formmed[0].medtype = "4"
            this.formmed[0].time = this.timemd
            this.formmed[0].type = this.typemedcer
            /*      console.log(this.comment)*/
            console.log(this.formmed)
            axios({
                method: 'post',
                url: '/medic/savedatatype1',
                data: this.formmed
            })
                .then(res => {
                   /* console.log(res)*/

                    if (res.data == "suc") {
                        alert("success")
                        $("#staticBackdrop").hide();
                        this.getdatadet(this.DE_number)
                    } else {
                        alert(res)
                    }                   /* this.company = res.data*/
                })
                .catch(err => {
                    console.log(err);
                })

        },
        editmed2() {

            this.formmed[0].fname = this.fnamemd
            this.formmed[0].lname = this.lnamemd
            this.formmed[0].adr = this.adrmd
            this.formmed[0].idcard = this.idcardmd
            this.formmed[0].ch1 = this.ch1md
            this.formmed[0].tex1 = this.tex1md
            this.formmed[0].ch2 = this.ch2md
            this.formmed[0].tex2 = this.tex2md
            this.formmed[0].ch3 = this.ch3md
            this.formmed[0].tex3 = this.tex3md
            this.formmed[0].ch4 = this.ch4md
            this.formmed[0].tex4 = this.tex4md
            this.formmed[0].tex5 = this.tex5md
            this.formmed[0].weight = String(this.weightmd)
            this.formmed[0].height = String(this.heightmd)
            this.formmed[0].blood = String(this.bloodmd)
            this.formmed[0].pulse = String(this.pulsemd)
            this.formmed[0].ch6 = this.ch6md
            this.formmed[0].tex6 = this.tex6md
            this.formmed[0].DateCus = this.DateCusmd
            this.formmed[0].titlen = this.titlenmd
            this.formmed[0].comment = this.commentmd
            this.formmed[0].id = this.ideditmed
            this.formmed[0].medtype = "5"
            this.formmed[0].time = this.timemd
            this.formmed[0].type = this.typemedcer
            /*      console.log(this.comment)*/
            console.log(this.formmed)
            axios({
                method: 'post',
                url: '/medic/editdatatype2',
                data: this.formmed
            })
                .then(res => {
                    /*console.log(res)*/

                    if (res.data == "suc") {
                        alert("success")
                        /*$("#staticBackdrop").hide();*/
                        this.getdatadet(this.DE_number)
                    } else {
                        alert(res)
                    }                   /* this.company = res.data*/
                })
                .catch(err => {
                    console.log(err);
                })

        },
        editmed1() {

            this.formmed[0].fname = this.fnamemd
            this.formmed[0].lname = this.lnamemd
            this.formmed[0].adr = this.adrmd
            this.formmed[0].idcard = this.idcardmd
            this.formmed[0].ch1 = this.ch1md
            this.formmed[0].tex1 = this.tex1md
            this.formmed[0].ch2 = this.ch2md
            this.formmed[0].tex2 = this.tex2md
            this.formmed[0].ch3 = this.ch3md
            this.formmed[0].tex3 = this.tex3md

            this.formmed[0].tex5 = this.tex5md
            this.formmed[0].weight = String(this.weightmd)
            this.formmed[0].height = String(this.heightmd)
            this.formmed[0].blood = String(this.bloodmd)
            this.formmed[0].pulse = String(this.pulsemd)
            this.formmed[0].ch6 = this.ch6md
            this.formmed[0].tex6 = this.tex6md
            this.formmed[0].DateCus = this.DateCusmd
            this.formmed[0].titlen = this.titlenmd
            this.formmed[0].comment = this.commentmd
            this.formmed[0].id = this.ideditmed
            this.formmed[0].medtype = "4"
            this.formmed[0].time = this.timemd
            this.formmed[0].type = this.typemedcer
            /*      console.log(this.comment)*/
            console.log(this.formmed)
            axios({
                method: 'post',
                url: '/medic/editdatatype1',
                data: this.formmed
            })
                .then(res => {
                    /* console.log(res)*/

                    if (res.data == "suc") {
                        alert("success")
                        /* $("#staticBackdrop").hide();*/
                        this.getdatadet(this.DE_number)
                    } else {
                        alert(res)
                    }                   /* this.company = res.data*/
                })
                .catch(err => {
                    console.log(err);
                })


        },
        editmed3() {

            this.formmed[0].DateCus = this.DateCusmd

            this.formmed[0].fname = this.fnamemd
            this.formmed[0].lname = this.lnamemd
            this.formmed[0].adr = this.adrmd
            this.formmed[0].idcard = this.idcardmd

            this.formmed[0].tex5 = this.tex5md
            this.formmed[0].ch6 = this.ch6md
            this.formmed[0].tex6 = this.tex6md

            this.formmed[0].comment = this.commentmd
            this.formmed[0].id = this.ideditmed
            this.formmed[0].titlen = this.titlenmd
            this.formmed[0].medtype = "5"
            this.formmed[0].time = this.timemd
            this.formmed[0].type = this.typemedcer
            /*      console.log(this.comment)*/
            console.log(this.formmed)
            axios({
                method: 'post',
                url: '/medic/editdatatype3',
                data: this.formmed
            })
                .then(res => {
                    /*console.log(res)*/

                    if (res.data == "suc") {
                        alert("success")
                        /*$("#staticBackdrop").hide();*/
                        this.getdatadet(this.DE_number)
                    } else {
                        alert(res)
                    }                   /* this.company = res.data*/
                })
                .catch(err => {
                    console.log(err);
                })

        }, del(id) {

            //alert("wwd")
            if (confirm("You want delete !!!") == true) {

                axios.get("/Patient/deldetail", {
                    params: {
                        id: id
                    }
                }).then(res => {
                    /* console.log(res.data);*/
                    this.getdatadet(this.DE_number)
                    /*console.log(this.getdatachkty)*/

                }).catch(err => {
                    console.log(err);
                })
                    

            }
        }, delpay(id) {

            //alert("wwd")
            if (confirm("You want delete !!!") == true) {

                axios.get("/Patient/delpay", {
                    params: {
                        id: id
                    }
                }).then(res => {
                    /* console.log(res.data);*/
                    
                    this.getdatadet(this.DE_number)
                    /*console.log(this.getdatachkty)*/

                }).catch(err => {
                    console.log(err);
                })


            }
        }, exportpa() {


            window.open(window.location.origin + "/Patient/Exportpatient", "'_blank'");



        }

    }, mounted: function () {
       /* $("#staticBackdrop").show();*/
      /*  console.log(this.DE_customere)*/
        axios.get("/Patient/Getprovince")
            .then(res => {
              
                this.getprovince = res.data
             /*   console.log(this.getprovince)*/

            }).catch(err => {
                console.log(err);
            })
      
        this.getpatient()
        this.getdatacom()
        this.getdatamedtype()
        this.getdatapaytype()
        this.getdatareceive()

        
    }

})