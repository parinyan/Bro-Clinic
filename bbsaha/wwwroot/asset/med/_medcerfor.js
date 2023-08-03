new Vue({
    el: "#_mertable",
    data: function () {
        return {
            formsubmit: [{}],
            formsubmitE: [{}],
            fname: "",
            lname: "",
            adr: "",
            idcard: "",
            ch1: "One",
            tex1: "",
            ch2: "One",
            tex2: "",
            ch3: "One",
            tex3: "",
            ch4: "One",
            tex4: "",
           
            tex5: "",
            weight: "",
            height: "",
            blood: "",
            pulse: "",
            ch6: "One",
            tex6: "",
            comment:"",
            commentE:"",
            DateCus: new Date().toISOString().slice(0, 10),
            DateCusE: "",
            viewdata: [],
            titlen: "นาย",
            titlenE: "",
            datadetail: [],
            id:[],
            fnameE: "",
            lnameE: "",
            adrE: "",
            idcardE: "",
            ch1E: "One",
            tex1E: "",
            ch2E: "One",
            tex2E: "",
            ch3E: "One",
            tex3E: "",
            ch4E: "One",
            tex4E: "",
            /* ch5: 0,*/
            tex5E: "",
            weightE: "",
            heightE: "",
            bloodE: "",
            pulseE: "",
            ch6E: "One",
            tex6E: "",
            formsubmitD: [{}]
        }
    }, methods: {
        CreateCer() {
            
            this.formsubmit[0].fname = this.fname
            this.formsubmit[0].lname = this.lname
            this.formsubmit[0].adr = this.adr
            this.formsubmit[0].idcard = this.idcard
            this.formsubmit[0].ch1 = this.ch1
            this.formsubmit[0].tex1 = this.tex1
            this.formsubmit[0].ch2 = this.ch2
            this.formsubmit[0].tex2 = this.tex2
            this.formsubmit[0].ch3 = this.ch3
            this.formsubmit[0].tex3 = this.tex3
            this.formsubmit[0].ch4= this.ch4
            this.formsubmit[0].tex4 = this.tex4
            this.formsubmit[0].tex5 = this.tex5
            this.formsubmit[0].weight = this.weight
            this.formsubmit[0].height = this.height
            this.formsubmit[0].blood = this.blood
            this.formsubmit[0].pulse = this.pulse
            this.formsubmit[0].ch6 = this.ch6
            this.formsubmit[0].tex6 = this.tex6
            this.formsubmit[0].DateCus = this.DateCus
            this.formsubmit[0].titlen = this.titlen
            this.formsubmit[0].comment = this.comment
            console.log(this.comment)
           /* console.log(this.formsubmit[0].fname)*/
            axios({
                method: 'post',
                url: '/medic/savedata',
                data: this.formsubmit
            })
                .then(res => {
                    console.log(res)

                    //if (res.data == "suc") {
                    //    alert("success")
                    //    $("#staticBackdrop").hide();
                    //    this.invoicedet()
                    //} else {
                    //    alert(res)
                    //}                   /* this.company = res.data*/
                })
                .catch(err => {
                    console.log(err);
                })

        }, printcer(id) {

           /* alert(id)*/
            window.open(window.location.origin + "/medic/GetPrintcertificatefor?id=" + id , "'_blank'");

        },
        toggleaccountdetail: function (id) {
         
            const formdata = new FormData();
            formdata.append('id', id);
            axios.post("/medic/Getdatadetailfor", formdata)
                .then(res => {

                    this.datadetail = res.data
                    for (var i = 0; i < res.data.length; i++) {
                        this.fnameE = res.data[i].firstNameCus
                        this.lnameE = res.data[i].lastNameCus
                        this.adrE = res.data[i].addressCus
                        this.idcardE = res.data[i].idcardCus
                        this.ch1E = (res.data[i].check_1 == true ? "Two" : "One")
                        this.ch2E = (res.data[i].check_2 == true ? "Two" : "One")
                        this.ch3E = (res.data[i].check_3 == true ? "Two" : "One")
                        this.ch4E = (res.data[i].check_4 == true ? "Two" : "One")
                        this.ch5E = (res.data[i].check_5 == true ? "Two" : "One")
                        this.tex1E = res.data[i].detail_1 
                        this.tex2E = res.data[i].detail_2 
                        this.tex3E = res.data[i].detail_3 
                        this.tex4E = res.data[i].detail_4 
                        this.tex5E = res.data[i].detail_5
                        this.weightE = (res.data[i].weightCus == null || res.data[i].weightCus == "" ? 0 : res.data[i].weightCus)
                        this.heightE = (res.data[i].heightCus == null || res.data[i].heightCus == "" ? 0 : res.data[i].heightCus)
                        this.bloodE = res.data[i].blood_pressureCus
                        this.pulseE = res.data[i].pulseCus
                        this.ch6E = (res.data[i].body_healthStatusCus == true ? "Two" : "One")
                        this.tex6E = res.data[i].body_healthDetailCus
                        this.commentE = res.data[i].commentCom
                        this.titlenE = res.data[i].nametitleCus
                        this.DateCusE = new Date(res.data[i].cerDate).toISOString().slice(0, 10)
                        /*alert()*/
                    }
                    console.log(this.datadetail)
                })
                .catch(err => {
                    console.log(err);
                });

        }, UpdateCer(id) {
            /*alert(this.heightE)*/
            this.formsubmitE[0].fname = this.fnameE
            this.formsubmitE[0].lname = this.lnameE
            this.formsubmitE[0].adr = this.adrE
            this.formsubmitE[0].idcard = this.idcardE
            this.formsubmitE[0].ch1 = this.ch1E
            this.formsubmitE[0].tex1 = this.tex1E
            this.formsubmitE[0].ch2 = this.ch2E
            this.formsubmitE[0].tex2 = this.tex2E
            this.formsubmitE[0].ch3 = this.ch3E
            this.formsubmitE[0].tex3 = this.tex3E
            this.formsubmitE[0].ch4 = this.ch4E
            this.formsubmitE[0].tex4 = this.tex4E
            this.formsubmitE[0].tex5 = this.tex5E
            this.formsubmitE[0].weight = String(this.weightE)
            this.formsubmitE[0].height = String(this.heightE)
            this.formsubmitE[0].blood = this.bloodE
            this.formsubmitE[0].pulse = String(this.pulseE)
            this.formsubmitE[0].ch6 = this.ch6E
            this.formsubmitE[0].tex6 = this.tex6E
            this.formsubmitE[0].DateCus = this.DateCusE
            this.formsubmitE[0].titlen = this.titlenE
            this.formsubmitE[0].comment = this.commentE
            this.formsubmitE[0].id = id
            console.log(this.comment)
            /* console.log(this.formsubmit[0].fname)*/
            axios({
                method: 'post',
                url: '/medic/Updatedata',
                data: this.formsubmitE
            })
                .then(res => {
                    console.log(res)

                    if (res.data == "suc") {
                        alert("success")
                        $("#staticBackdrop").hide();
                       
                    } else {
                        alert(res)
                    }                   /* this.company = res.data*/
                })
                .catch(err => {
                    console.log(err);
                })


        }, getdataview() {
            axios.get("/medic/GetMedicCer")
                .then(res => {
                    console.log(res.data);

                    this.viewdata = res.data;
                    for (var i = 0; i < res.data.length; i++)
                        this.id = res.data[i].id

                }).catch(err => {
                    console.log(err);
                })
        },
        toggledel: function (id) {
            
            this.formsubmitD[0].id = id
            if (confirm("คุณต้องการลบใบรับรองแพทย์ใบนี้ใช่หรือไหม ?") == true) {

                axios({
                    method: 'post',
                    url: '/medic/Delmer',
                    data: this.formsubmitD
                })
                    .then(res => {
                        console.log(res)

                        if (res.data == "suc") {
                            alert("success")
                            /* $("#staticBackdrop").hide();*/
                            this.getdataview()
                        } else {
                            alert(res)
                        }                   /* this.company = res.data*/
                    })
                    .catch(err => {
                        console.log(err);
                    })

         
            }

        }

    }, mounted: function () {

        axios.get("/medic/GetMedicCer")
            .then(res => {
                console.log(res.data);

                this.viewdata = res.data;
                for (var i = 0; i < res.data.length; i++) 
                    this.id = res.data[i].id
               
            }).catch(err => {
                console.log(err);
            })


    }

})