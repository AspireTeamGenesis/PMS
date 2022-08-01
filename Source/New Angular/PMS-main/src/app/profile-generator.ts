import {
    AlignmentType,
    Document,
    HeadingLevel,
    Packer,
    Paragraph,
    TabStopPosition,
    TabStopType,
    TextRun
  } from "docx";
  import { ViewprofileComponent } from "./viewprofile/viewprofile.component";
  let PHONE_NUMBER = "";
  let DESIGNATION = "";
  let EMAIL = "";
  let SOCIAL_MEDIA_URL="";
  let OBJECTIVE="";
  let NAME="";
  
  export class DocumentCreator {
  
  
    // tslint:disable-next-line: typedef
    public create([education,project,skill,language]: any): Document {
      console.log(education)
      console.log(project)
      console.log(skill)
      console.log(language)
      // console.log(objective)
      // console.warn(ps.personaldetails[0]["socialmedia"][0]["socialMedia_Link"])
      const document = new Document({
        sections: [
          {
            children: [
              new Paragraph({
                text: "My Profile",
                heading: HeadingLevel.TITLE
              }),
              this.createContactInfo(PHONE_NUMBER, DESIGNATION, EMAIL,NAME),
              console.error(PHONE_NUMBER, DESIGNATION, EMAIL,NAME),
              this.createpersonalInfo(OBJECTIVE),
              console.error(OBJECTIVE),
              // this.createpersonalInfo(ps),
  
              // this.createHeading("Objective"),
              // ...objective
              //   .map((objective: { objective: any; }) => {
              //     const arr: Paragraph[] = [];
              //     arr.push(
              //       this.createInstitutionHeader1(
              //         objective.objective,
              //       )
              //     );
              //     // arr.push(
              //     //   this.createRoleText(
              //     //     `${education.course} - ${education.degree} - ${education.percentage}`
              //     //   )
              //     // );
  
              //     // const bulletPoints = this.splitParagraphIntoBullets(
              //     //   education.percentage
              //     // );
              //     // bulletPoints.forEach(bulletPoint => {
              //     //   arr.push(this.createBullet(bulletPoint));
              //     // });
  
              //     return arr;
              //   })
              //   .reduce((prev: any, curr: any) => prev.concat(curr), []),
  
              this.createHeading("Education"),
              ...education
                .map((education: { college: any; startingyear: any; endingyear: any; course: any; degree: any; percentage: any; }) => {
                  const arr: Paragraph[] = [];
                  arr.push(
                    this.createInstitutionHeader(
                      education.college,
                      `${education.startingyear} - ${education.endingyear}`
                    )
                  );
                  arr.push(
                    this.createRoleText(
                      `${education.degree} - ${education.course} - ${education.percentage}`
                    )
                  );
  
                  // const bulletPoints = this.splitParagraphIntoBullets(
                  //   education.percentage
                  // );
                  // bulletPoints.forEach(bulletPoint => {
                  //   arr.push(this.createBullet(bulletPoint));
                  // });
  
                  return arr;
                })
                .reduce((prev: any, curr: any) => prev.concat(curr), []),
  
                this.createHeading("Project"),
              ...project
                .map((project: { projectname: any; startingYear: any; endingYear: any; projectdescription: any; toolsused: any; role: any; }) => {
                  const arr: Paragraph[] = [];
                  arr.push(
                    this.createInstitutionHeader(
                      project.projectname,
                      `${project.startingYear} - ${project.endingYear}`
                    )
                  );
                  arr.push(
                    this.createRoleText(
                      `${project.projectdescription} - ${project.toolsused} - ${project.role}`
                    )
                  );
  
                  // const bulletPoints = this.splitParagraphIntoBullets(
                  //   project.percentage
                  // );
                  // bulletPoints.forEach(bulletPoint => {
                  //   arr.push(this.createBullet(bulletPoint));
                  // });
  
                  return arr;
                })
                .reduce((prev: any, curr: any) => prev.concat(curr), []),
  
                this.createHeading("Skills"),
                this.createHeading("Domain-Technology"),
              ...skill
                .map((skill: { domainname: any; technologyname: any;  }) => {
                  const arr: Paragraph[] = [];
                  arr.push(
                    this.createInstitutionHeader1(
                      // skill.domainname,
                      `${skill.domainname} - ${skill.technologyname}`
                    )
                  );
                  // arr.push(
                  //   this.createRoleText(
                  //     `${project.projectdescription} - ${project.toolsused} - ${project.role}`
                  //   )
                  // );
  
                  // const bulletPoints = this.splitParagraphIntoBullets(
                  //   project.percentage
                  // );
                  // bulletPoints.forEach(bulletPoint => {
                  //   arr.push(this.createBullet(bulletPoint));
                  // });
  
                  return arr;
                })
                .reduce((prev: any, curr: any) => prev.concat(curr), []),
  
                this.createHeading("Languages Known"),
              ...language
                .map((language: { languageName: any; }) => {
                  const arr: Paragraph[] = [];
                  arr.push(
                    this.createInstitutionHeader1(
                      // skill.domainname,
                      `${language.languageName}`
                    )
                  );
                  // arr.push(
                  //   this.createRoleText(
                  //     `${project.projectdescription} - ${project.toolsused} - ${project.role}`
                  //   )
                  // );
  
                  // const bulletPoints = this.splitParagraphIntoBullets(
                  //   project.percentage
                  // );
                  // bulletPoints.forEach(bulletPoint => {
                  //   arr.push(this.createBullet(bulletPoint));
                  // });
  
                  return arr;
                })
                .reduce((prev: any, curr: any) => prev.concat(curr), []),
              // this.createHeading("Experience"),
              // ...experiences
              //   .map((position: { company: { name: string; }; startDate: any; endDate: any; isCurrent: boolean; title: string; summary: string; }) => {
              //     const arr: Paragraph[] = [];
  
              //     arr.push(
              //       this.createInstitutionHeader(
              //         position.company.name,
              //         this.createPositionDateText(
              //           position.startDate,
              //           position.endDate,
              //           position.isCurrent
              //         )
              //       )
              //     );
              //     arr.push(this.createRoleText(position.title));
  
              //     const bulletPoints = this.splitParagraphIntoBullets(
              //       position.summary
              //     );
  
              //     bulletPoints.forEach(bulletPoint => {
              //       arr.push(this.createBullet(bulletPoint));
              //     });
  
              //     return arr;
              //   })
              //   .reduce((prev: any, curr: any) => prev.concat(curr), []),
              // this.createHeading("Skills, Achievements and Interests"),
              // this.createSubHeading("Skills"),
              // this.createSkillList(skills),
              // this.createSubHeading("Achievements"),
              // ...this.createAchivementsList(achivements),
              // this.createSubHeading("Interests"),
              // this.createInterests(
              //   "Programming, Technology, Music Production, Web Design, 3D Modelling, Dancing."
              // ),
              // this.createHeading("References"),
              
            ]
          }
        ]
      });
      // console.log(PHONE_NUMBER);
      return document;
    }
    // createpersonalInfo(SOCIAL_MEDIA_URL: any): Paragraph | import("docx").Table | import("docx").TableOfContents {
    //   throw new Error("Method not implemented.");
    // }
  
  
  
    public createContactInfo(phoneNumber: string, designation: string, email: string, name:string): Paragraph {
      console.warn(phoneNumber + designation + email + name)
      PHONE_NUMBER=phoneNumber,
      DESIGNATION=designation,
      EMAIL=email,
      NAME=name
  
      return new Paragraph({
        alignment: AlignmentType.CENTER,
        children: [
          
          new TextRun(
  
            (`Name: ${NAME} | Mobile: ${PHONE_NUMBER} | Designation: ${designation} | Email: ${email} `),
          
            
          ),
          
          // new TextRun({
          //   text: "Address: 58 Elm Avenue, Kent ME4 6ER, UK",
          //   break: 1
          // })
        ]
      });
    }
  
    public createpersonalInfo(objective : any): Paragraph {
      console.warn(objective)
      OBJECTIVE=objective
  
      return new Paragraph({
        alignment: AlignmentType.CENTER,
        children: [
          
          new TextRun(
  
            (`Objective: ${OBJECTIVE}`),
          
            
          ),
          
          // new TextRun({
          //   text: "Address: 58 Elm Avenue, Kent ME4 6ER, UK",
          //   break: 1
          // })
        ]
      });
    }
  
   
  
    public createHeading(text: string): Paragraph {
      return new Paragraph({
        text: text,
        heading: HeadingLevel.HEADING_1,
        thematicBreak: true
      });
    }
  
    public createSubHeading(text: string): Paragraph {
      return new Paragraph({
        text: text,
        heading: HeadingLevel.HEADING_2
      });
    }
  
    public createInstitutionHeader(
      institutionName: string,
      dateText: string
    ): Paragraph {
      return new Paragraph({
        tabStops: [
          {
            type: TabStopType.RIGHT,
            position: TabStopPosition.MAX
          }
        ],
        children: [
          new TextRun({
            text: institutionName,
            bold: true
          }),
          new TextRun({
            text: `\t${dateText}`,
            bold: true
          })
        ]
      });
    }
  
    public createRoleText(roleText: string): Paragraph {
      return new Paragraph({
        children: [
          new TextRun({
            text: roleText,
            italics: true
          })
        ]
      });
    }
  
    public createBullet(text: string): Paragraph {
      return new Paragraph({
        text: text,
        bullet: {
          level: 0
        }
      });
    }
  
    // tslint:disable-next-line:no-any
    public createSkillList(skills: any[]): Paragraph {
      return new Paragraph({
        children: [new TextRun(skills.map(skill => skill.name).join(", ") + ".")]
      });
    }
  
    // tslint:disable-next-line:no-any
    public createAchivementsList(achivements: any[]): Paragraph[] {
      return achivements.map(
        achievement =>
          new Paragraph({
            text: achievement.name,
            bullet: {
              level: 0
            }
          })
      );
    }
  
    public createInterests(interests: string): Paragraph {
      return new Paragraph({
        children: [new TextRun(interests)]
      });
    }
  
    public splitParagraphIntoBullets(text: string): string[] {
      return text.split("/n");
      // return text.split("\n\n");
  
    }
  
    // tslint:disable-next-line:no-any
    public createPositionDateText(
      startDate: any,
      endDate: any,
      isCurrent: boolean
    ): string {
      const startDateText =
        this.getMonthFromInt(startDate.month) + ". " + startDate.year;
      const endDateText = isCurrent
        ? "Present"
        : `${this.getMonthFromInt(endDate.month)}. ${endDate.year}`;
  
      return `${startDateText} - ${endDateText}`;
    }
  
    public getMonthFromInt(value: number): string {
      switch (value) {
        case 1:
          return "Jan";
        case 2:
          return "Feb";
        case 3:
          return "Mar";
        case 4:
          return "Apr";
        case 5:
          return "May";
        case 6:
          return "Jun";
        case 7:
          return "Jul";
        case 8:
          return "Aug";
        case 9:
          return "Sept";
        case 10:
          return "Oct";
        case 11:
          return "Nov";
        case 12:
          return "Dec";
        default:
          return "N/A";
      }
    }
  
    public createInstitutionHeader1(
      institutionName: string,
      // dateText: string
    ): Paragraph {
      return new Paragraph({
        tabStops: [
          {
            type: TabStopType.RIGHT,
            position: TabStopPosition.MAX
          }
        ],
        children: [
          new TextRun({
            text: institutionName,
            bold: true
          }),
        ]
      });
    }
  }
  
  
  