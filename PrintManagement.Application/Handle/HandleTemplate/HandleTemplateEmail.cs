﻿using PrintManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintManagement.Application.Handle.HandleTemplate
{
    public  class HandleTemplateEmail
    {
        public static string GenerateNotificationBillEmail(Bill bill)
        {
            string htmlContent = $@"
                                    <html
  dir=""ltr""
  xmlns=""http://www.w3.org/1999/xhtml""
  xmlns:o=""urn:schemas-microsoft-com:office:office""
  lang=""en""
>
  <head>
    <meta charset=""UTF-8"" />
    <meta content=""width=device-width, initial-scale=1"" name=""viewport"" />
    <meta name=""x-apple-disable-message-reformatting"" />
    <meta http-equiv=""X-UA-Compatible"" content=""IE=edge"" />
    <meta content=""telephone=no"" name=""format-detection"" />
    <title>New Template 3</title>
    <!--[if (mso 16)
      ]><style type=""text/css"">
        a {{
          text-decoration: none;
        }}
      </style><!
    [endif]-->
    <!--[if gte mso 9
      ]><style>
        sup {{
          font-size: 100% !important;
        }}
      </style><!
    [endif]-->
    <!--[if gte mso 9
      ]><xml>
        <o:OfficeDocumentSettings>
          <o:AllowPNG></o:AllowPNG> <o:PixelsPerInch>96</o:PixelsPerInch>
        </o:OfficeDocumentSettings>
      </xml>
    <![endif]-->
    <style type=""text/css"">
      #outlook a {{
        padding: 0;
      }}
      .es-button {{
        mso-style-priority: 100 !important;
        text-decoration: none !important;
      }}
      a[x-apple-data-detectors] {{
        color: inherit !important;
        text-decoration: none !important;
        font-size: inherit !important;
        font-family: inherit !important;
        font-weight: inherit !important;
        line-height: inherit !important;
      }}
      .es-desk-hidden {{
        display: none;
        float: left;
        overflow: hidden;
        width: 0;
        max-height: 0;
        line-height: 0;
        mso-hide: all;
      }}
      @media only screen and (max-width: 600px) {{
        p,
        ul li,
        ol li,
        a {{
          line-height: 150% !important;
        }}
        h1,
        h2,
        h3,
        h1 a,
        h2 a,
        h3 a {{
          line-height: 120% !important;
        }}
        h1 {{
          font-size: 36px !important;
          text-align: left;
        }}
        h2 {{
          font-size: 26px !important;
          text-align: left;
        }}
        h3 {{
          font-size: 20px !important;
          text-align: left;
        }}
        .es-header-body h1 a,
        .es-content-body h1 a,
        .es-footer-body h1 a {{
          font-size: 36px !important;
          text-align: left;
        }}
        .es-header-body h2 a,
        .es-content-body h2 a,
        .es-footer-body h2 a {{
          font-size: 26px !important;
          text-align: left;
        }}
        .es-header-body h3 a,
        .es-content-body h3 a,
        .es-footer-body h3 a {{
          font-size: 20px !important;
          text-align: left;
        }}
        .es-menu td a {{
          font-size: 12px !important;
        }}
        .es-header-body p,
        .es-header-body ul li,
        .es-header-body ol li,
        .es-header-body a {{
          font-size: 14px !important;
        }}
        .es-content-body p,
        .es-content-body ul li,
        .es-content-body ol li,
        .es-content-body a {{
          font-size: 14px !important;
        }}
        .es-footer-body p,
        .es-footer-body ul li,
        .es-footer-body ol li,
        .es-footer-body a {{
          font-size: 14px !important;
        }}
        .es-infoblock p,
        .es-infoblock ul li,
        .es-infoblock ol li,
        .es-infoblock a {{
          font-size: 12px !important;
        }}
        *[class=""gmail-fix""] {{
          display: none !important;
        }}
        .es-m-txt-c,
        .es-m-txt-c h1,
        .es-m-txt-c h2,
        .es-m-txt-c h3 {{
          text-align: center !important;
        }}
        .es-m-txt-r,
        .es-m-txt-r h1,
        .es-m-txt-r h2,
        .es-m-txt-r h3 {{
          text-align: right !important;
        }}
        .es-m-txt-l,
        .es-m-txt-l h1,
        .es-m-txt-l h2,
        .es-m-txt-l h3 {{
          text-align: left !important;
        }}
        .es-m-txt-r img,
        .es-m-txt-c img,
        .es-m-txt-l img {{
          display: inline !important;
        }}
        .es-button-border {{
          display: inline-block !important;
        }}
        a.es-button,
        button.es-button {{
          font-size: 20px !important;
          display: inline-block !important;
        }}
        .es-adaptive table,
        .es-left,
        .es-right {{
          width: 100% !important;
        }}
        .es-content table,
        .es-header table,
        .es-footer table,
        .es-content,
        .es-footer,
        .es-header {{
          width: 100% !important;
          max-width: 600px !important;
        }}
        .es-adapt-td {{
          display: block !important;
          width: 100% !important;
        }}
        .adapt-img {{
          width: 100% !important;
          height: auto !important;
        }}
        .es-m-p0 {{
          padding: 0 !important;
        }}
        .es-m-p0r {{
          padding-right: 0 !important;
        }}
        .es-m-p0l {{
          padding-left: 0 !important;
        }}
        .es-m-p0t {{
          padding-top: 0 !important;
        }}
        .es-m-p0b {{
          padding-bottom: 0 !important;
        }}
        .es-m-p20b {{
          padding-bottom: 20px !important;
        }}
        .es-mobile-hidden,
        .es-hidden {{
          display: none !important;
        }}
        tr.es-desk-hidden,
        td.es-desk-hidden,
        table.es-desk-hidden {{
          width: auto !important;
          overflow: visible !important;
          float: none !important;
          max-height: inherit !important;
          line-height: inherit !important;
        }}
        tr.es-desk-hidden {{
          display: table-row !important;
        }}
        table.es-desk-hidden {{
          display: table !important;
        }}
        td.es-desk-menu-hidden {{
          display: table-cell !important;
        }}
        .es-menu td {{
          width: 1% !important;
        }}
        table.es-table-not-adapt,
        .esd-block-html table {{
          width: auto !important;
        }}
        table.es-social {{
          display: inline-block !important;
        }}
        table.es-social td {{
          display: inline-block !important;
        }}
        .es-m-p5 {{
          padding: 5px !important;
        }}
        .es-m-p5t {{
          padding-top: 5px !important;
        }}
        .es-m-p5b {{
          padding-bottom: 5px !important;
        }}
        .es-m-p5r {{
          padding-right: 5px !important;
        }}
        .es-m-p5l {{
          padding-left: 5px !important;
        }}
        .es-m-p10 {{
          padding: 10px !important;
        }}
        .es-m-p10t {{
          padding-top: 10px !important;
        }}
        .es-m-p10b {{
          padding-bottom: 10px !important;
        }}
        .es-m-p10r {{
          padding-right: 10px !important;
        }}
        .es-m-p10l {{
          padding-left: 10px !important;
        }}
        .es-m-p15 {{
          padding: 15px !important;
        }}
        .es-m-p15t {{
          padding-top: 15px !important;
        }}
        .es-m-p15b {{
          padding-bottom: 15px !important;
        }}
        .es-m-p15r {{
          padding-right: 15px !important;
        }}
        .es-m-p15l {{
          padding-left: 15px !important;
        }}
        .es-m-p20 {{
          padding: 20px !important;
        }}
        .es-m-p20t {{
          padding-top: 20px !important;
        }}
        .es-m-p20r {{
          padding-right: 20px !important;
        }}
        .es-m-p20l {{
          padding-left: 20px !important;
        }}
        .es-m-p25 {{
          padding: 25px !important;
        }}
        .es-m-p25t {{
          padding-top: 25px !important;
        }}
        .es-m-p25b {{
          padding-bottom: 25px !important;
        }}
        .es-m-p25r {{
          padding-right: 25px !important;
        }}
        .es-m-p25l {{
          padding-left: 25px !important;
        }}
        .es-m-p30 {{
          padding: 30px !important;
        }}
        .es-m-p30t {{
          padding-top: 30px !important;
        }}
        .es-m-p30b {{
          padding-bottom: 30px !important;
        }}
        .es-m-p30r {{
          padding-right: 30px !important;
        }}
        .es-m-p30l {{
          padding-left: 30px !important;
        }}
        .es-m-p35 {{
          padding: 35px !important;
        }}
        .es-m-p35t {{
          padding-top: 35px !important;
        }}
        .es-m-p35b {{
          padding-bottom: 35px !important;
        }}
        .es-m-p35r {{
          padding-right: 35px !important;
        }}
        .es-m-p35l {{
          padding-left: 35px !important;
        }}
        .es-m-p40 {{
          padding: 40px !important;
        }}
        .es-m-p40t {{
          padding-top: 40px !important;
        }}
        .es-m-p40b {{
          padding-bottom: 40px !important;
        }}
        .es-m-p40r {{
          padding-right: 40px !important;
        }}
        .es-m-p40l {{
          padding-left: 40px !important;
        }}
        button.es-button {{
          width: 100%;
        }}
        .es-desk-hidden {{
          display: table-row !important;
          width: auto !important;
          overflow: visible !important;
          max-height: inherit !important;
        }}
      }}
      @media screen and (max-width: 384px) {{
        .mail-message-content {{
          width: 414px !important;
        }}
      }}
    </style>
  </head>
  <body
    style=""
      width: 100%;
      font-family: arial, 'helvetica neue', helvetica, sans-serif;
      -webkit-text-size-adjust: 100%;
      -ms-text-size-adjust: 100%;
      padding: 0;
      margin: 0;
    ""
  >
    <div
      dir=""ltr""
      class=""es-wrapper-color""
      lang=""en""
      style=""background-color: #fafafa""
    >
      <!--[if gte mso 9
        ]><v:background xmlns:v=""urn:schemas-microsoft-com:vml"" fill=""t"">
          <v:fill type=""tile"" color=""#fafafa""></v:fill> </v:background
      ><![endif]-->
      <table
        class=""es-wrapper""
        width=""100%""
        cellspacing=""0""
        cellpadding=""0""
        role=""none""
        style=""
          mso-table-lspace: 0pt;
          mso-table-rspace: 0pt;
          border-collapse: collapse;
          border-spacing: 0px;
          padding: 0;
          margin: 0;
          width: 100%;
          height: 100%;
          background-repeat: repeat;
          background-position: center top;
          background-color: #fafafa;
        ""
      >
        <tr>
          <td valign=""top"" style=""padding: 0; margin: 0"">
            <table
              class=""es-content""
              cellspacing=""0""
              cellpadding=""0""
              align=""center""
              role=""none""
              style=""
                mso-table-lspace: 0pt;
                mso-table-rspace: 0pt;
                border-collapse: collapse;
                border-spacing: 0px;
                table-layout: fixed !important;
                width: 100%;
              ""
            >
              <tr>
                <td align=""center"" style=""padding: 0; margin: 0"">
                  <table
                    class=""es-content-body""
                    style=""
                      mso-table-lspace: 0pt;
                      mso-table-rspace: 0pt;
                      border-collapse: collapse;
                      border-spacing: 0px;
                      background-color: transparent;
                      width: 600px;
                    ""
                    cellspacing=""0""
                    cellpadding=""0""
                    align=""center""
                    role=""none""
                  >
                    <tr>
                      <td
                        align=""left""
                        style=""
                          margin: 0;
                          padding-bottom: 5px;
                          padding-top: 20px;
                          padding-left: 20px;
                          padding-right: 20px;
                        ""
                      >
                        <table
                          width=""100%""
                          cellspacing=""0""
                          cellpadding=""0""
                          role=""none""
                          style=""
                            mso-table-lspace: 0pt;
                            mso-table-rspace: 0pt;
                            border-collapse: collapse;
                            border-spacing: 0px;
                          ""
                        >
                          <tr>
                            <td
                              valign=""top""
                              align=""center""
                              style=""padding: 0; margin: 0; width: 560px""
                            >
                              <table
                                width=""100%""
                                cellspacing=""0""
                                cellpadding=""0""
                                role=""presentation""
                                style=""
                                  mso-table-lspace: 0pt;
                                  mso-table-rspace: 0pt;
                                  border-collapse: collapse;
                                  border-spacing: 0px;
                                ""
                              >
                                <tr>
                                  <td
                                    align=""right""
                                    style=""padding: 0; margin: 0""
                                  >
                                    <p
                                      style=""
                                        margin: 0;
                                        -webkit-text-size-adjust: none;
                                        -ms-text-size-adjust: none;
                                        mso-line-height-rule: exactly;
                                        font-family: arial, 'helvetica neue',
                                          helvetica, sans-serif;
                                        line-height: 21px;
                                        color: #666666;
                                        font-size: 14px;
                                      ""
                                    >
                                      October 1st, 2021
                                    </p>
                                  </td>
                                </tr>
                              </table>
                            </td>
                          </tr>
                        </table>
                      </td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table>
            <table
              class=""es-content""
              cellspacing=""0""
              cellpadding=""0""
              align=""center""
              role=""none""
              style=""
                mso-table-lspace: 0pt;
                mso-table-rspace: 0pt;
                border-collapse: collapse;
                border-spacing: 0px;
                table-layout: fixed !important;
                width: 100%;
              ""
            >
              <tr>
                <td align=""center"" style=""padding: 0; margin: 0"">
                  <table
                    class=""es-content-body""
                    cellspacing=""0""
                    cellpadding=""0""
                    bgcolor=""#ffffff""
                    align=""center""
                    role=""none""
                    style=""
                      mso-table-lspace: 0pt;
                      mso-table-rspace: 0pt;
                      border-collapse: collapse;
                      border-spacing: 0px;
                      background-color: #ffffff;
                      width: 600px;
                    ""
                  >
                    <tr>
                      <td
                        align=""left""
                        style=""
                          padding: 0;
                          margin: 0;
                          padding-top: 20px;
                          padding-left: 20px;
                          padding-right: 20px;
                        ""
                      >
                        <table
                          width=""100%""
                          cellspacing=""0""
                          cellpadding=""0""
                          role=""none""
                          style=""
                            mso-table-lspace: 0pt;
                            mso-table-rspace: 0pt;
                            border-collapse: collapse;
                            border-spacing: 0px;
                          ""
                        >
                          <tr>
                            <td
                              valign=""top""
                              align=""center""
                              style=""padding: 0; margin: 0; width: 560px""
                            >
                              <table
                                width=""100%""
                                cellspacing=""0""
                                cellpadding=""0""
                                role=""presentation""
                                style=""
                                  mso-table-lspace: 0pt;
                                  mso-table-rspace: 0pt;
                                  border-collapse: collapse;
                                  border-spacing: 0px;
                                ""
                              >
                                <tr>
                                  <td
                                    class=""es-m-txt-l""
                                    align=""left""
                                    style=""
                                      padding: 0;
                                      margin: 0;
                                      padding-top: 5px;
                                      padding-bottom: 10px;
                                    ""
                                  >
                                    <h3
                                      style=""
                                        margin: 0;
                                        line-height: 24px;
                                        mso-line-height-rule: exactly;
                                        font-family: arial, 'helvetica neue',
                                          helvetica, sans-serif;
                                        font-size: 20px;
                                        font-style: normal;
                                        font-weight: bold;
                                        color: #333333;
                                      ""
                                    >
                                      Dear *|FNAME|*,
                                    </h3>
                                  </td>
                                </tr>
                                <tr>
                                  <td
                                    align=""left""
                                    style=""
                                      padding: 0;
                                      margin: 0;
                                      padding-top: 5px;
                                      padding-bottom: 10px;
                                    ""
                                  >
                                    <p
                                      style=""
                                        margin: 0;
                                        -webkit-text-size-adjust: none;
                                        -ms-text-size-adjust: none;
                                        mso-line-height-rule: exactly;
                                        font-family: arial, 'helvetica neue',
                                          helvetica, sans-serif;
                                        line-height: 21px;
                                        color: #333333;
                                        font-size: 14px;
                                      ""
                                    >
                                      It's been a year since you joined our
                                      team.<br />You had your ups and downs. But
                                      I am extremely happy you are one of us.<br /><br />Your
                                      experience in Mobile Apps Development is
                                      something we truly needed.<br />Now we
                                      provide our clients both with professional
                                      email marketing and high-quality mobile
                                      apps that help them boost their
                                      sales.&nbsp;<br /><br />It's been a nice
                                      year together. You showed yourself as a
                                      skilled professional.<br />Now it's time
                                      to move on.<br />We decided to start a new
                                      direction -- Mobile Apps for external
                                      IT&nbsp;companies -- which we want you to
                                      run. Your duties will be:&nbsp;
                                    </p>
                                    <ul>
                                      <li
                                        style=""
                                          -webkit-text-size-adjust: none;
                                          -ms-text-size-adjust: none;
                                          mso-line-height-rule: exactly;
                                          font-family: arial, 'helvetica neue',
                                            helvetica, sans-serif;
                                          line-height: 21px;
                                          margin-bottom: 15px;
                                          margin-left: 0;
                                          color: #333333;
                                          font-size: 14px;
                                        ""
                                      >
                                        you will be a team leader&nbsp;of your
                                        own unit;
                                      </li>
                                      <li
                                        style=""
                                          -webkit-text-size-adjust: none;
                                          -ms-text-size-adjust: none;
                                          mso-line-height-rule: exactly;
                                          font-family: arial, 'helvetica neue',
                                            helvetica, sans-serif;
                                          line-height: 21px;
                                          margin-bottom: 15px;
                                          margin-left: 0;
                                          color: #333333;
                                          font-size: 14px;
                                        ""
                                      >
                                        interviewing new developers;
                                      </li>
                                      <li
                                        style=""
                                          -webkit-text-size-adjust: none;
                                          -ms-text-size-adjust: none;
                                          mso-line-height-rule: exactly;
                                          font-family: arial, 'helvetica neue',
                                            helvetica, sans-serif;
                                          line-height: 21px;
                                          margin-bottom: 15px;
                                          margin-left: 0;
                                          color: #333333;
                                          font-size: 14px;
                                        ""
                                      >
                                        monitoring performance of the entire
                                        unit;
                                      </li>
                                      <li
                                        style=""
                                          -webkit-text-size-adjust: none;
                                          -ms-text-size-adjust: none;
                                          mso-line-height-rule: exactly;
                                          font-family: arial, 'helvetica neue',
                                            helvetica, sans-serif;
                                          line-height: 21px;
                                          margin-bottom: 15px;
                                          margin-left: 0;
                                          color: #333333;
                                          font-size: 14px;
                                        ""
                                      >
                                        communication with clients after they
                                        placed an order to better understand
                                        what they need;
                                      </li>
                                      <li
                                        style=""
                                          -webkit-text-size-adjust: none;
                                          -ms-text-size-adjust: none;
                                          mso-line-height-rule: exactly;
                                          font-family: arial, 'helvetica neue',
                                            helvetica, sans-serif;
                                          line-height: 21px;
                                          margin-bottom: 15px;
                                          margin-left: 0;
                                          color: #333333;
                                          font-size: 14px;
                                        ""
                                      >
                                        if you like, you can continue to
                                        work&nbsp;on Mobile Apps development on
                                        your own, too.
                                      </li>
                                    </ul>
                                    <p
                                      style=""
                                        margin: 0;
                                        -webkit-text-size-adjust: none;
                                        -ms-text-size-adjust: none;
                                        mso-line-height-rule: exactly;
                                        font-family: arial, 'helvetica neue',
                                          helvetica, sans-serif;
                                        line-height: 21px;
                                        color: #333333;
                                        font-size: 14px;
                                      ""
                                    >
                                      We hope you will take&nbsp;our offer as we
                                      trust in you.&nbsp;<br />Please, give us
                                      your answer by October 4th.<br /><br />Regards,<br />Aaron
                                      Parker.
                                    </p>
                                  </td>
                                </tr>
                              </table>
                            </td>
                          </tr>
                        </table>
                      </td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table>
            <table
              class=""es-content""
              cellspacing=""0""
              cellpadding=""0""
              align=""center""
              role=""none""
              style=""
                mso-table-lspace: 0pt;
                mso-table-rspace: 0pt;
                border-collapse: collapse;
                border-spacing: 0px;
                table-layout: fixed !important;
                width: 100%;
              ""
            >
              <tr>
                <td align=""center"" style=""padding: 0; margin: 0"">
                  <table
                    class=""es-content-body""
                    cellspacing=""0""
                    cellpadding=""0""
                    bgcolor=""#ffffff""
                    align=""center""
                    role=""none""
                    style=""
                      mso-table-lspace: 0pt;
                      mso-table-rspace: 0pt;
                      border-collapse: collapse;
                      border-spacing: 0px;
                      background-color: #ffffff;
                      width: 600px;
                    ""
                  >
                    <tr>
                      <td align=""left"" style=""padding: 20px; margin: 0"">
                        <!--[if mso]><table style=""width:560px"" cellpadding=""0"" cellspacing=""0""><tr><td style=""width:296px"" valign=""top""><![endif]-->
                        <table
                          class=""es-left""
                          cellspacing=""0""
                          cellpadding=""0""
                          align=""left""
                          role=""none""
                          style=""
                            mso-table-lspace: 0pt;
                            mso-table-rspace: 0pt;
                            border-collapse: collapse;
                            border-spacing: 0px;
                            float: left;
                          ""
                        >
                          <tr>
                            <td
                              align=""left""
                              style=""padding: 0; margin: 0; width: 276px""
                            >
                              <table
                                width=""100%""
                                cellspacing=""0""
                                cellpadding=""0""
                                role=""presentation""
                                style=""
                                  mso-table-lspace: 0pt;
                                  mso-table-rspace: 0pt;
                                  border-collapse: collapse;
                                  border-spacing: 0px;
                                ""
                              >
                                <tr>
                                  <td
                                    class=""es-m-txt-l""
                                    style=""
                                      padding: 0;
                                      margin: 0;
                                      font-size: 0px;
                                    ""
                                    align=""left""
                                  >
                                    <img
                                      src=""https://eeslewt.stripocdn.email/content/guids/CABINET_5855bdf78ca537e4d15709a026af93a6/images/89501626684388018.png""
                                      alt
                                      style=""
                                        display: block;
                                        border: 0;
                                        outline: none;
                                        text-decoration: none;
                                        -ms-interpolation-mode: bicubic;
                                      ""
                                      width=""186""
                                      height=""68""
                                    />
                                  </td>
                                </tr>
                              </table>
                            </td>
                            <td
                              class=""es-hidden""
                              style=""padding: 0; margin: 0; width: 20px""
                            ></td>
                          </tr>
                        </table>
                        <!--[if mso]></td><td style=""width:96px"" valign=""top""><![endif]-->
                        <table
                          class=""es-left""
                          cellspacing=""0""
                          cellpadding=""0""
                          align=""left""
                          role=""none""
                          style=""
                            mso-table-lspace: 0pt;
                            mso-table-rspace: 0pt;
                            border-collapse: collapse;
                            border-spacing: 0px;
                            float: left;
                          ""
                        >
                          <tr>
                            <td
                              align=""left""
                              style=""padding: 0; margin: 0; width: 96px""
                            >
                              <table
                                width=""100%""
                                cellspacing=""0""
                                cellpadding=""0""
                                role=""presentation""
                                style=""
                                  mso-table-lspace: 0pt;
                                  mso-table-rspace: 0pt;
                                  border-collapse: collapse;
                                  border-spacing: 0px;
                                ""
                              >
                                <tr>
                                  <td
                                    class=""es-m-txt-c""
                                    style=""
                                      padding: 0;
                                      margin: 0;
                                      padding-top: 5px;
                                      padding-bottom: 5px;
                                      font-size: 0px;
                                    ""
                                    align=""right""
                                  >
                                    <img
                                      src=""https://eeslewt.stripocdn.email/content/guids/CABINET_5855bdf78ca537e4d15709a026af93a6/images/12581621865359778.png""
                                      alt
                                      style=""
                                        display: block;
                                        border: 0;
                                        outline: none;
                                        text-decoration: none;
                                        -ms-interpolation-mode: bicubic;
                                      ""
                                      width=""96""
                                      height=""96""
                                    />
                                  </td>
                                </tr>
                              </table>
                            </td>
                          </tr>
                        </table>
                        <!--[if mso]></td><td style=""width:20px""></td><td style=""width:148px"" valign=""top""><![endif]-->
                        <table
                          class=""es-right""
                          cellspacing=""0""
                          cellpadding=""0""
                          align=""right""
                          role=""none""
                          style=""
                            mso-table-lspace: 0pt;
                            mso-table-rspace: 0pt;
                            border-collapse: collapse;
                            border-spacing: 0px;
                            float: right;
                          ""
                        >
                          <tr>
                            <td
                              align=""left""
                              style=""padding: 0; margin: 0; width: 148px""
                            >
                              <table
                                width=""100%""
                                cellspacing=""0""
                                cellpadding=""0""
                                role=""presentation""
                                style=""
                                  mso-table-lspace: 0pt;
                                  mso-table-rspace: 0pt;
                                  border-collapse: collapse;
                                  border-spacing: 0px;
                                ""
                              >
                                <tr>
                                  <td
                                    class=""es-m-txt-c""
                                    align=""left""
                                    style=""padding: 0; margin: 0""
                                  >
                                    <h3
                                      style=""
                                        margin: 0;
                                        line-height: 30px;
                                        mso-line-height-rule: exactly;
                                        font-family: arial, 'helvetica neue',
                                          helvetica, sans-serif;
                                        font-size: 20px;
                                        font-style: normal;
                                        font-weight: bold;
                                        color: #333333;
                                      ""
                                    >
                                      Aaron Parker
                                    </h3>
                                    <p
                                      style=""
                                        margin: 0;
                                        -webkit-text-size-adjust: none;
                                        -ms-text-size-adjust: none;
                                        mso-line-height-rule: exactly;
                                        font-family: arial, 'helvetica neue',
                                          helvetica, sans-serif;
                                        line-height: 21px;
                                        color: #333333;
                                        font-size: 14px;
                                      ""
                                    >
                                      CEO of ""Style Casual""
                                    </p>
                                    <p
                                      style=""
                                        margin: 0;
                                        -webkit-text-size-adjust: none;
                                        -ms-text-size-adjust: none;
                                        mso-line-height-rule: exactly;
                                        font-family: arial, 'helvetica neue',
                                          helvetica, sans-serif;
                                        line-height: 21px;
                                        color: #333333;
                                        font-size: 14px;
                                      ""
                                    >
                                      <a
                                        target=""_blank""
                                        style=""
                                          -webkit-text-size-adjust: none;
                                          -ms-text-size-adjust: none;
                                          mso-line-height-rule: exactly;
                                          text-decoration: none;
                                          color: #333333;
                                          font-size: 14px;
                                          line-height: 21px;
                                        ""
                                        href=""""
                                        >+0 (000) 123 456 789</a
                                      >
                                    </p>
                                    <p
                                      style=""
                                        margin: 0;
                                        -webkit-text-size-adjust: none;
                                        -ms-text-size-adjust: none;
                                        mso-line-height-rule: exactly;
                                        font-family: arial, 'helvetica neue',
                                          helvetica, sans-serif;
                                        line-height: 21px;
                                        color: #333333;
                                        font-size: 14px;
                                      ""
                                    >
                                      <a
                                        target=""_blank""
                                        href=""mailto:aaronparker@email.com""
                                        style=""
                                          -webkit-text-size-adjust: none;
                                          -ms-text-size-adjust: none;
                                          mso-line-height-rule: exactly;
                                          text-decoration: underline;
                                          color: #333333;
                                          font-size: 14px;
                                          line-height: 21px;
                                        ""
                                        >parker@email.com</a
                                      >
                                    </p>
                                  </td>
                                </tr>
                                <tr>
                                  <td
                                    class=""es-m-txt-c""
                                    style=""
                                      padding: 0;
                                      margin: 0;
                                      padding-top: 5px;
                                      padding-bottom: 5px;
                                      font-size: 0;
                                    ""
                                    align=""left""
                                  >
                                    <table
                                      class=""es-table-not-adapt es-social""
                                      cellspacing=""0""
                                      cellpadding=""0""
                                      role=""presentation""
                                      style=""
                                        mso-table-lspace: 0pt;
                                        mso-table-rspace: 0pt;
                                        border-collapse: collapse;
                                        border-spacing: 0px;
                                      ""
                                    >
                                      <tr>
                                        <td
                                          valign=""top""
                                          align=""center""
                                          style=""
                                            padding: 0;
                                            margin: 0;
                                            padding-right: 10px;
                                          ""
                                        >
                                          <img
                                            title=""Facebook""
                                            src=""https://eeslewt.stripocdn.email/content/assets/img/social-icons/logo-black/facebook-logo-black.png""
                                            alt=""Fb""
                                            width=""24""
                                            height=""24""
                                            style=""
                                              display: block;
                                              border: 0;
                                              outline: none;
                                              text-decoration: none;
                                              -ms-interpolation-mode: bicubic;
                                            ""
                                          />
                                        </td>
                                        <td
                                          valign=""top""
                                          align=""center""
                                          style=""
                                            padding: 0;
                                            margin: 0;
                                            padding-right: 10px;
                                          ""
                                        >
                                          <img
                                            title=""Twitter""
                                            src=""https://eeslewt.stripocdn.email/content/assets/img/social-icons/logo-black/twitter-logo-black.png""
                                            alt=""Tw""
                                            width=""24""
                                            height=""24""
                                            style=""
                                              display: block;
                                              border: 0;
                                              outline: none;
                                              text-decoration: none;
                                              -ms-interpolation-mode: bicubic;
                                            ""
                                          />
                                        </td>
                                        <td
                                          valign=""top""
                                          align=""center""
                                          style=""
                                            padding: 0;
                                            margin: 0;
                                            padding-right: 10px;
                                          ""
                                        >
                                          <img
                                            title=""Instagram""
                                            src=""https://eeslewt.stripocdn.email/content/assets/img/social-icons/logo-black/instagram-logo-black.png""
                                            alt=""Inst""
                                            width=""24""
                                            height=""24""
                                            style=""
                                              display: block;
                                              border: 0;
                                              outline: none;
                                              text-decoration: none;
                                              -ms-interpolation-mode: bicubic;
                                            ""
                                          />
                                        </td>
                                        <td
                                          valign=""top""
                                          align=""center""
                                          style=""padding: 0; margin: 0""
                                        >
                                          <img
                                            title=""Youtube""
                                            src=""https://eeslewt.stripocdn.email/content/assets/img/social-icons/logo-black/youtube-logo-black.png""
                                            alt=""Yt""
                                            width=""24""
                                            height=""24""
                                            style=""
                                              display: block;
                                              border: 0;
                                              outline: none;
                                              text-decoration: none;
                                              -ms-interpolation-mode: bicubic;
                                            ""
                                          />
                                        </td>
                                      </tr>
                                    </table>
                                  </td>
                                </tr>
                              </table>
                            </td>
                          </tr>
                        </table>
                        <!--[if mso]></td></tr></table><![endif]-->
                      </td>
                    </tr>
                  </table>
                </td>
              </tr>
            </table>
          </td>
        </tr>
      </table>
    </div>
  </body>
</html>
                                   ";
            return htmlContent;
        }
    }
}
