<template>
  <div class="Courses internal-page" id="hr">
    <h1>
      <img src="../../../assets/layout/img/course.png" alt="courses" />
      Hr page
    </h1>

    <div class="custom-form vec-kinds fortab">
      <div class="cu-container">
        <div class="cu-form-group special shadow" style="max-width: 1000px">
          <!-- Page Content -->
          <div class="container">
            <ul
              class="row nav nav-tabs nav-justified mt-3 mb-3 mr-0 ml-0 w-100 p-3 shadow rounded text-center border header-title"
            >
              <li class="col-lg-4 nav-item">
                <a class="nav-link active" data-toggle="tab" href="#paid-vacation">
                  Paid Vacation
                  <span
                    class="bg-danger pull-right number-border"
                    v-show="
                      allVacRrq.filter((x) => x.Deduction_name.trim() == 'Paid').length >
                      0
                    "
                  >
                    {{
                      allVacRrq.filter((x) => x.Deduction_name.trim() == "Paid").length
                    }}
                  </span>
                </a>
              </li>
              <li class="col-lg-4 nav-item">
                <a class="nav-link" data-toggle="tab" href="#work-requests">
                  Work Requests
                  <span
                    class="bg-danger pull-right number-border"
                    v-show="WorkRequests.length > 0"
                  >
                    {{ WorkRequests.length }}
                  </span>
                </a>
              </li>
              <li class="col-lg-4 nav-item">
                <a class="nav-link" data-toggle="tab" href="#unpaid-vacation">
                  Unpaid Vacation
                  <span
                    class="bg-danger pull-right number-border"
                    v-show="
                      allVacRrq.filter((x) => x.Deduction_name.trim() == 'Unpaid')
                        .length > 0
                    "
                  >
                    {{
                      allVacRrq.filter((x) => x.Deduction_name.trim() == "Unpaid").length
                    }}
                  </span>
                </a>
              </li>
            </ul>

            <div class="tab-content mr-0 mt-4 ml-0 w-100 pt-2 rounded bg-light fortab">
              <div class="filter text-center d-block d-md-block d-lg-none d-xl-none">
                <h3>Filter:</h3>
                <select class="form-control" v-model="activeType">
                  <option
                    v-for="vacation in HR_Vacation_Type"
                    :key="vacation.id"
                    :value="vacation.Type_Name.trim()"
                  >
                    {{ vacation.Type_Name }}
                  </option>
                </select>
              </div>
              <div
                class="tab-pane fade show active container-fluid"
                id="paid-vacation"
                style="max-height: 600px"
              >
                <div class="row">
                  <div class="col-lg-9 w-100 overflow-auto">
                    <div class="tab-content flex-center ml-0 mr-0 mt-0 p-0 w-100 rounded">
                      <!-- Vacations Types -->
                      <div
                        class="row tab-pane fade show p-3 overflow-auto bg-light"
                        v-for="(vacation, i) in HR_Vacation_Type"
                        :key="vacation.id"
                        :class="
                          vacation.Type_Name.trim() == activeType ? ' active show' : ''
                        "
                        :id="vacation.Type_Name.split(' ').join('')"
                        style="max-height: 600px"
                      >
                        <div
                          v-if="
                            allVacRrq.filter(
                              (x) => x.Vacation_Type_name.trim() == vacation.Type_Name
                            ).length > 0
                          "
                        >
                          <div
                            class="card bg-white mr-auto ml-auto mb-3 p-4 rounded w-100 shadow-sm"
                            v-for="request in allVacRrq.filter(
                              (x) => x.Vacation_Type_name.trim() == vacation.Type_Name
                            )"
                            :key="request.id"
                          >
                            <div class="row">
                              <div class="col-md-12">
                                <div class="candidates-img float-left mr-4">
                                  <img
                                    src="../../../assets/layout/img/person.jpg"
                                    alt=""
                                    class="img-fluid d-block rounded border border-secondary"
                                  />
                                </div>
                                <div class="candidates-list-desc job-single-meta pt-2">
                                  <h4 class="mb-2 text-dark">
                                    {{ request.Requester_name }}
                                  </h4>

                                  <div
                                    v-if="
                                      HR_Vacations_Period.filter(
                                        (x) => x.Request_id == request.id
                                      ).length > 0
                                    "
                                  >
                                    <div
                                      class="row"
                                      v-show="
                                        HR_Vacations_Period.filter(
                                          (x) =>
                                            x.Request_id == request.id &&
                                            x.Date_from == x.Date_to
                                        ).length > 0
                                      "
                                    >
                                      <div class="col-md-12">
                                        <div class="param param-inline">
                                          <div
                                            class="text-info overflow-auto"
                                            style="max-height: 50px"
                                          >
                                            Requested Dates:
                                            <span class="text-secondary">
                                              {{
                                                HR_Vacations_Period.filter(
                                                  (x) => x.Request_id == request.id
                                                )
                                                  .map((x) => x.Date_from)
                                                  .join()
                                                  .replace(/,/g, "  ,  ")
                                              }}
                                            </span>
                                          </div>
                                        </div>
                                      </div>
                                    </div>
                                    <div
                                      class="row"
                                      v-show="
                                        HR_Vacations_Period.filter(
                                          (x) =>
                                            x.Request_id == request.id &&
                                            x.Date_from == x.Date_to
                                        ).length == 0
                                      "
                                    >
                                      <div class="col-md-12 col-lg-6">
                                        <div class="param param-inline">
                                          <span class="text-info"
                                            ><i
                                              class="fa fa-calendar-o mr-2"
                                              aria-hidden="true"
                                            ></i
                                            >Start date:
                                            <span class="text-secondary">
                                              {{
                                                HR_Vacations_Period.filter(
                                                  (x) => x.Request_id == request.id
                                                )[0].Date_from
                                              }}
                                            </span>
                                          </span>
                                        </div>
                                      </div>
                                      <div class="col-md-12 col-lg-6">
                                        <div class="param param-inline two">
                                          <span class="text-info"
                                            ><i
                                              class="fa fa-calendar-o mr-2"
                                              aria-hidden="true"
                                            ></i
                                            >End date:
                                            <span class="text-secondary">
                                              {{
                                                HR_Vacations_Period.filter(
                                                  (x) => x.Request_id == request.id
                                                )[0].Date_to
                                              }}
                                            </span>
                                          </span>
                                        </div>
                                      </div>
                                    </div>
                                  </div>

                                  <div class="row mt-3">
                                    <div class="col-md-12">
                                      <div>
                                        <a
                                          href="#"
                                          @click.prevent="
                                            updateVacStatus(
                                              request.id,
                                              4,
                                              request.Requester_id
                                            )
                                          "
                                          :class="
                                            ([4, 5].indexOf(request.Status) > -1
                                              ? 'disabled '
                                              : '') + 'btn btn-sm btn-success'
                                          "
                                          >Approve</a
                                        >
                                        <a
                                          href="#"
                                          @click.prevent="updateVacStatus(request.id, 5)"
                                          :class="
                                            ([4, 5].indexOf(request.Status) > -1
                                              ? 'disabled '
                                              : '') + 'btn btn-sm btn-danger'
                                          "
                                          >Reject</a
                                        >
                                        <a
                                          href="#"
                                          class="btn btn-sm btn-info open-pop"
                                          data-pop-name="details-popup"
                                          v-on:click.prevent="
                                            popUp(request, 'detailsPop')
                                          "
                                          >Details</a
                                        >
                                      </div>
                                    </div>
                                  </div>
                                  <hr />
                                  <div class="row">
                                    <div class="col-md-10">
                                      <p class="text-muted mb-2 f-14 pull-left forleft">
                                        <i class="fa fa-list mr-3" aria-hidden="true"></i
                                        >Request Status :
                                        <span
                                          v-if="request.Status == 2"
                                          class="text-success"
                                          >Accepted from manger</span
                                        >
                                        <span
                                          v-else-if="request.Status == 4"
                                          class="text-success"
                                          >Accepted from HR</span
                                        >
                                        <span
                                          v-else-if="request.Status == 5"
                                          class="text-danger"
                                          >Rejected from HR</span
                                        >
                                      </p>
                                    </div>
                                    <div class="col-md-2">
                                      <a href="#" class="pull-right forright">
                                        <i
                                          class="fa fa-trash fa-lg btn text-danger"
                                          aria-hidden="true"
                                          @click.prevent="
                                            deleteVacRequest(request.id, true, i)
                                          "
                                        >
                                        </i>
                                      </a>
                                    </div>
                                  </div>
                                </div>
                              </div>
                            </div>
                          </div>
                        </div>
                        <div v-else class="text-center bg-white pt-5 pb-5 shadow-sm">
                          There is no requests for
                          {{ vacation.Type_Name.split(" ").join("") }} vacations
                        </div>
                      </div>
                    </div>
                  </div>
                  <div class="col-lg-3 d-none d-lg-block d-xl-block">
                    <ul class="w-100 m-0 p-0 list-unstyled nav nav-tabs flex-column">
                      <li
                        class=""
                        v-for="(vacation, i) in HR_Vacation_Type"
                        :key="vacation.id"
                      >
                        <a
                          class="bg-white rounded border mb-2 pt-2 pb-2"
                          :class="
                            i == 0
                              ? 'nav-link align-middle active'
                              : 'nav-link align-middle'
                          "
                          data-toggle="tab"
                          :href="'#' + vacation.Type_Name.split(' ').join('')"
                          >{{ vacation.Type_Name }}
                          <span
                            class="bg-danger pull-right number-border"
                            v-if="
                              allVacRrq.filter(
                                (x) => x.Vacation_Type_name.trim() == vacation.Type_Name
                              ).length > 0
                            "
                          >
                            {{
                              allVacRrq.filter(
                                (x) => x.Vacation_Type_name.trim() == vacation.Type_Name
                              ).length
                            }}
                          </span>
                        </a>
                      </li>
                    </ul>
                  </div>
                </div>
              </div>
              <div
                class="row tab-pane row fade p-3 overflow-auto bg-light"
                id="work-requests"
                role="tabpanel"
                aria-labelledby="profile-tab-md"
                style="max-height: 600px"
              >
                <div v-if="WorkRequests.length > 0">
                  <div
                    class="card bg-white mb-3 p-4 rounded w-100 shadow-sm"
                    v-for="request in WorkRequests"
                    :key="request.id"
                  >
                    <div class="row">
                      <div class="col-md-12">
                        <div class="candidates-img float-left mr-4">
                          <img
                            src="../../../assets/layout/img/person.jpg"
                            alt=""
                            class="img-fluid d-block rounded border border-secondary"
                          />
                        </div>
                        <div class="candidates-list-desc job-single-meta pt-2">
                          <h4 class="mb-2 text-dark">
                            {{
                              adminusersData.filter((x) => x.Emp_id == request.Emp_id)[0]
                                .FullName
                            }}
                          </h4>
                          <div class="row">
                            <div class="col-md-12 col-lg-6">
                              <p class="text-muted f-15 mb-0">
                                <i class="fa fa-user mr-2" aria-hidden="true"></i>
                                {{
                                  adminusersData.filter(
                                    (x) => x.Emp_id == request.Emp_id
                                  )[0].Job_Description
                                }}
                              </p>
                            </div>
                            <div class="col-md-12 col-lg-6">
                              <p class="f-15 mb-0">
                                <a href="" class="text-muted"
                                  ><i class="fa fa-pencil mr-2" aria-hidden="true"></i>
                                  <span>Department : </span
                                  ><span class="text-success">{{
                                    adminusersData.filter(
                                      (x) => x.Emp_id == request.Emp_id
                                    )[0].Dept_name
                                  }}</span>
                                </a>
                              </p>
                            </div>
                          </div>

                          <div class="row">
                            <div class="col-md-6">
                              <div class="param param-inline">
                                <div class="text-primary">
                                  Requested Date:
                                  <span class="text-secondary">{{
                                    request.Date_From
                                  }}</span>
                                </div>
                              </div>
                            </div>
                            <div class="col-md-6">
                              <div class="param param-inline">
                                <p
                                  class="text-muted mb-2 f-14 pull-left text-danger forleft"
                                >
                                  Status :
                                  <span v-if="request.Status == 2" class="text-success"
                                    >Accepted from manger</span
                                  >
                                  <span
                                    v-else-if="request.Status == 4"
                                    class="text-success"
                                    >Accepted from HR</span
                                  >
                                  <span
                                    v-else-if="request.Status == 5"
                                    class="text-danger"
                                    >Rejected from HR</span
                                  >
                                  <span
                                    v-else-if="request.Status == 6"
                                    class="text-primary"
                                    >Pending day off request</span
                                  >
                                  <span
                                    v-else-if="request.Status == 7"
                                    class="text-success"
                                    >Day off request accepted from manger</span
                                  >
                                  <span
                                    v-else-if="request.Status == 8"
                                    class="text-success"
                                    >Day off request accepted from hr</span
                                  >
                                </p>
                              </div>
                            </div>
                          </div>

                          <div class="row mt-3">
                            <div class="col-md-12">
                              <div class="">
                                <a
                                  href="#"
                                  @click.prevent="
                                    updateWorkStatus(
                                      request.id,
                                      4,
                                      request.Emp_id,
                                      request.Date_To
                                    )
                                  "
                                  :class="
                                    ([4, 5].indexOf(request.Status) > -1
                                      ? 'disabled '
                                      : '') + 'btn btn-sm btn-success'
                                  "
                                  >Approve</a
                                >
                                <a
                                  href="#"
                                  @click.prevent="updateWorkStatus(request.id, 5)"
                                  :class="
                                    ([4, 5].indexOf(request.Status) > -1
                                      ? 'disabled '
                                      : '') + 'btn btn-sm btn-danger'
                                  "
                                  >Reject</a
                                >
                              </div>
                            </div>
                          </div>

                          <hr />
                          <div class="row">
                            <div class="col-md-6">
                              <p
                                class="text-muted mb-2 f-14 pull-left text-danger forleft"
                              >
                                <i class="fa fa-list mr-3" aria-hidden="true"></i>Employee
                                Comment : <span>{{ request.Requester_Comment }}</span>
                              </p>
                            </div>
                            <div class="col-md-6">
                              <a href="#" class="pull-right">
                                <i
                                  class="fa fa-trash fa-lg btn text-danger"
                                  aria-hidden="true"
                                  @click.prevent="deleteWorkRequest(request.id, true, i)"
                                >
                                </i>
                              </a>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
                <div v-else class="text-center bg-white pt-5 pb-5 shadow-sm">
                  There are no work requests
                </div>
              </div>
              <div
                class="row tab-pane row fade p-3 overflow-auto bg-light"
                id="unpaid-vacation"
                role="tabpanel"
                aria-labelledby="contact-tab-md"
                style="max-height: 600px"
              >
                <div v-if="Unpaid.length > 0">
                  <div
                    class="card bg-white mb-3 p-4 rounded w-100 shadow-sm"
                    v-for="request in allVacRrq.filter(
                      (x) => x.Deduction_name.trim() == 'Unpaid'
                    )"
                    :key="request.id"
                  >
                    <div class="row">
                      <div class="col-md-12">
                        <div class="candidates-img float-left mr-4">
                          <img
                            src="../../../assets/layout/img/person.jpg"
                            alt=""
                            class="img-fluid d-block rounded border border-secondary"
                          />
                        </div>
                        <div class="candidates-list-desc job-single-meta pt-2">
                          <h4 class="mb-2 text-dark">
                            {{
                              adminusersData.filter(
                                (x) => x.Emp_id == request.Requester_id
                              )[0].FullName
                            }}
                          </h4>
                          <div class="row">
                            <div class="col-md-12 col-lg-6">
                              <p class="text-muted f-15 mb-0">
                                <i class="fa fa-user mr-2" aria-hidden="true"></i>
                                {{
                                  adminusersData.filter(
                                    (x) => x.Emp_id == request.Requester_id
                                  )[0].Job_Description
                                }}
                              </p>
                            </div>
                            <div class="col-md-12 col-lg-6">
                              <p class="f-15 mb-0">
                                <a href="" class="text-muted"
                                  ><i class="fa fa-pencil mr-2" aria-hidden="true"></i>
                                  <span>Department : </span
                                  ><span class="text-success">{{
                                    adminusersData.filter(
                                      (x) => x.Emp_id == request.Requester_id
                                    )[0].Dept_name
                                  }}</span>
                                </a>
                              </p>
                            </div>
                          </div>

                          <div
                            class="row mt-2"
                            v-if="
                              HR_Vacations_Period.filter(
                                (x) => x.Request_id == request.id
                              ).length > 0
                            "
                          >
                            <div class="col-md-12 col-lg-6">
                              <div class="param param-inline">
                                <div class="text-primary">
                                  Start date:
                                  <span class="text-secondary">
                                    {{
                                      HR_Vacations_Period.filter(
                                        (x) => x.Request_id == request.id
                                      )[0].Date_from
                                    }}
                                  </span>
                                </div>
                              </div>
                            </div>
                            <div class="col-md-12 col-lg-6">
                              <div class="param param-inline two">
                                <div class="text-primary">
                                  End date:
                                  <span class="text-secondary">
                                    {{
                                      HR_Vacations_Period.filter(
                                        (x) => x.Request_id == request.id
                                      )[0].Date_to
                                    }}
                                  </span>
                                </div>
                              </div>
                            </div>
                          </div>

                          <div class="row mt-3">
                            <div class="col-md-12">
                              <div>
                                <a
                                  href="#"
                                  @click.prevent="updateVacStatus(request.id, 4)"
                                  :class="
                                    ([4, 5].indexOf(request.Status) > -1
                                      ? 'disabled '
                                      : '') + 'btn btn-sm btn-success'
                                  "
                                  >Approve</a
                                >
                                <a
                                  href="#"
                                  @click.prevent="updateVacStatus(request.id, 5)"
                                  :class="
                                    ([4, 5].indexOf(request.Status) > -1
                                      ? 'disabled '
                                      : '') + 'btn btn-sm btn-danger'
                                  "
                                  >Reject</a
                                >
                                <a
                                  href="#"
                                  class="btn btn-sm btn-info open-pop"
                                  data-pop-name="details-popup"
                                  v-on:click.prevent="popUp(request, 'detailsPop')"
                                  >Details</a
                                >
                              </div>
                            </div>
                          </div>

                          <hr />
                          <div class="row">
                            <div class="col-md-10">
                              <p class="text-muted mb-2 f-14 pull-left forleft">
                                <i class="fa fa-list mr-3" aria-hidden="true"></i>Request
                                Status :
                                <span v-if="request.Status == 2" class="text-success"
                                  >Accepted from manger</span
                                >
                                <span v-else-if="request.Status == 4" class="text-success"
                                  >Accepted from HR</span
                                >
                                <span v-else-if="request.Status == 5" class="text-danger"
                                  >Rejected from HR</span
                                >
                              </p>
                            </div>
                            <div class="col-md-2">
                              <a href="#" class="pull-right forright">
                                <i
                                  class="fa fa-trash fa-lg btn text-danger"
                                  aria-hidden="true"
                                  @click.prevent="deleteVacRequest(request.id, true, i)"
                                >
                                </i>
                              </a>
                            </div>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
                <div v-else class="text-center bg-white pt-5 pb-5 shadow-sm">
                  There are no unpaid vacation requests
                </div>
              </div>
            </div>
          </div>
          <!-- /.container -->
        </div>
      </div>

      <!-- start details popup in new box -->

      <div v-if="vacRequest">
        <div
          v-bind:class="
            vacRequest['detailsPop']
              ? 'details-popup popup active'
              : 'details-popup popup'
          "
          v-if="vacRequest['detailsPop'] == true"
        >
          <div class="popup-body" style="max-width: 1000px">
            <div class="container-fluid custom-form m-auto pb-4" style="max-width: 800px">
              <div class="cu-container">
                <span class="close-pop">Close</span>

                <!--- detailed -->
                <div class="col-md-12">
                  <div>
                    <div class="social-timeline-card shadow">
                      <div class="card-header bg-white border">
                        <ul class="nav nav-tabs card-header-tabs tab">
                          <li class="nav-item">
                            <a
                              class="nav-link tablinks stylish"
                              data-tab="#request-details"
                              >Request Details
                            </a>
                          </li>
                          <li class="nav-item">
                            <a class="nav-link tablinks" data-tab="#requester-history"
                              >Requester History
                            </a>
                          </li>
                        </ul>
                      </div>

                      <div class="card-body">
                        <div
                          id="request-details"
                          class="general info tabcontent active overflow-auto"
                          style="height: 500px"
                        >
                          <div
                            class="cu-form-group special shadow-sm grouped rounded mb-3 bg-light pr-3 pl-3"
                          >
                            <div class="row">
                              <!-- employee name -->
                              <div class="cu-field col-md-6">
                                <h3 class="cu-label">
                                  <label>Employee Name :</label>
                                </h3>
                                <div class="cu-input text-box">
                                  <span class="fa fa-edit"></span>
                                  {{
                                    adminusersData.filter(
                                      (x) => x.Emp_id == vacRequest.Requester_id
                                    )[0].FullName
                                  }}
                                </div>
                              </div>

                              <!-- employee id -->
                              <div class="cu-field col-md-6">
                                <h3 class="cu-label">
                                  <label>Employee Id :</label>
                                </h3>
                                <div class="cu-input text-box">
                                  <span class="fa fa-edit"></span>
                                  {{
                                    adminusersData.filter(
                                      (x) => x.Emp_id == vacRequest.Requester_id
                                    )[0].Emp_id
                                  }}
                                </div>
                              </div>

                              <!-- department -->
                              <div class="cu-field col-md-6">
                                <h3 class="cu-label">
                                  <label>Department Name :</label>
                                </h3>
                                <div class="cu-input text-box">
                                  <span class="fa fa-edit"></span>
                                  {{
                                    adminusersData.filter(
                                      (x) => x.Emp_id == vacRequest.Requester_id
                                    )[0].Dept_name
                                  }}
                                </div>
                              </div>

                              <!-- Branch Name -->
                              <div class="cu-field col-md-6">
                                <h3 class="cu-label">
                                  <label>Branch Name :</label>
                                </h3>
                                <div class="cu-input text-box">
                                  <span class="fa fa-edit"></span>
                                  {{
                                    adminusersData.filter(
                                      (x) => x.Emp_id == vacRequest.Requester_id
                                    )[0].Branch_name
                                  }}
                                </div>
                              </div>

                              <!-- total balance -->
                              <div class="cu-field col-md-6">
                                <h3 class="cu-label">
                                  <label>Total Vacation Balance :</label>
                                </h3>
                                <div class="cu-input text-box" v-if="Employees_Balance">
                                  <span class="fa fa-edit"></span>
                                  {{ Employees_Balance.Annual_Balance }}
                                </div>
                                <div class="cu-input text-box" v-else>
                                  <span class="fa fa-edit"></span>
                                  No total balance has been set yet
                                </div>
                              </div>

                              <!-- casual balance -->
                              <div class="cu-field col-md-6">
                                <h3 class="cu-label">
                                  <label>total casual balance :</label>
                                </h3>
                                <div class="cu-input text-box" v-if="Employees_Balance">
                                  <span class="fa fa-edit"></span>
                                  {{ Employees_Balance.Casual_Balance }}
                                </div>
                                <div class="cu-input text-box" v-else>
                                  <span class="fa fa-edit"></span>
                                  No casual balance has been set yet
                                </div>
                              </div>
                            </div>
                          </div>

                          <!-- about vacation -->
                          <div
                            class="cu-form-group special shadow-sm grouped rounded mb-3 bg-light pr-3 pl-3"
                          >
                            <div class="row">
                              <!-- time off type -->
                              <div class="cu-field col-md-6">
                                <h3 class="cu-label">
                                  <label>Vacation Type :</label>
                                </h3>
                                <div class="cu-input text-box">
                                  <span class="fa fa-edit"></span>
                                  {{ vacRequest.Deduction_name }}
                                </div>
                              </div>

                              <!-- Purpose of Time-Off -->
                              <div
                                class="cu-field col-md-6"
                                v-if="vacRequest.Deduction_name.trim() == 'Paid'"
                              >
                                <h3 class="cu-label">
                                  <label>Purpose of Vacation :</label>
                                </h3>
                                <div class="cu-input text-box">
                                  <span class="fa fa-edit"></span>
                                  {{ vacRequest.Vacation_Type_name }}
                                </div>
                              </div>

                              <!-- Reason of the vacation-->
                              <div
                                class="cu-field col-md-6"
                                v-if="vacRequest.Deduction_name.trim() == 'Unpaid'"
                              >
                                <h3 class="cu-label">
                                  <label>Reason Of The Vacation :</label>
                                </h3>
                                <div class="cu-input text-box">
                                  <span class="fa fa-edit"></span>
                                  {{ vacRequest.Vacation_Type_Others }}
                                </div>
                              </div>

                              <!-- delegated to-->
                              <div class="cu-field col-md-12">
                                <h3 class="cu-label">
                                  <label>Delegated To :</label>
                                </h3>
                                <div class="cu-input text-box" style="max-width: 100%">
                                  <span class="fa fa-edit"></span>
                                  {{ vacRequest.Delegation_EmpName }}
                                </div>
                              </div>
                            </div>
                          </div>

                          <!-- vacation dates -->
                          <div
                            class="cu-form-group special shadow-sm grouped rounded mb-3 bg-light pr-3 pl-3"
                          >
                            <div class="row">
                              <!-- Start Date -->
                              <div
                                class="cu-field col-md-12"
                                v-show="
                                  HR_Vacations_Period.filter(
                                    (x) =>
                                      x.Request_id == vacRequest.id &&
                                      x.Date_from == x.Date_to
                                  ).length > 0
                                "
                              >
                                <h3 class="cu-label">
                                  <label>Requested dates :</label>
                                </h3>
                                <div class="cu-input text-box" style="max-width: 100%">
                                  <span class="fa fa-edit"></span>
                                  {{
                                    HR_Vacations_Period.filter(
                                      (x) => x.Request_id == vacRequest.id
                                    )
                                      .map((x) => x.Date_from)
                                      .join()
                                      .replace(/,/g, "  ,  ")
                                  }}
                                </div>
                              </div>

                              <div
                                class="cu-field col-md-6"
                                v-show="
                                  HR_Vacations_Period.filter(
                                    (x) =>
                                      x.Request_id == vacRequest.id &&
                                      x.Date_from == x.Date_to
                                  ).length == 0
                                "
                              >
                                <h3 class="cu-label">
                                  <label>Start Date :</label>
                                </h3>
                                <div class="cu-input text-box">
                                  <span class="fa fa-edit"></span>
                                  {{
                                    HR_Vacations_Period.filter(
                                      (x) => x.Request_id == vacRequest.id
                                    )[0].Date_from
                                  }}
                                </div>
                              </div>

                              <!-- End Date -->
                              <div
                                class="cu-field col-md-6 d-none"
                                v-show="
                                  HR_Vacations_Period.filter(
                                    (x) =>
                                      x.Request_id == vacRequest.id &&
                                      x.Date_from == x.Date_to
                                  ).length > 0
                                "
                              >
                                <h3 class="cu-label">
                                  <label>End Date :</label>
                                </h3>
                                <div class="cu-input text-box">
                                  <span class="fa fa-edit"></span>
                                  {{
                                    HR_Vacations_Period.filter(
                                      (x) => x.Request_id == vacRequest.id
                                    )[0].Date_to
                                  }}
                                </div>
                              </div>
                              <div
                                class="cu-field col-md-6"
                                v-show="
                                  HR_Vacations_Period.filter(
                                    (x) =>
                                      x.Request_id == vacRequest.id &&
                                      x.Date_from == x.Date_to
                                  ).length == 0
                                "
                              >
                                <h3 class="cu-label">
                                  <label>End Date :</label>
                                </h3>
                                <div class="cu-input text-box">
                                  <span class="fa fa-edit"></span>
                                  {{
                                    HR_Vacations_Period.filter(
                                      (x) => x.Request_id == vacRequest.id
                                    )[0].Date_to
                                  }}
                                </div>
                              </div>

                              <!-- Vacation Days -->
                              <div
                                class="cu-field col-md-6"
                                v-show="
                                  HR_Vacations_Period.filter(
                                    (x) =>
                                      x.Request_id == vacRequest.id &&
                                      x.Date_from == x.Date_to
                                  ).length > 0
                                "
                              >
                                <h3 class="cu-label">
                                  <label>Vacation Days :</label>
                                </h3>
                                <div class="cu-input text-box">
                                  <span class="fa fa-edit"></span>
                                  {{
                                    HR_Vacations_Period.filter(
                                      (x) => x.Request_id == vacRequest.id
                                    ).length
                                  }}
                                  days
                                </div>
                              </div>
                              <div
                                class="cu-field col-md-6"
                                v-show="
                                  HR_Vacations_Period.filter(
                                    (x) =>
                                      x.Request_id == vacRequest.id &&
                                      x.Date_from == x.Date_to
                                  ).length == 0
                                "
                              >
                                <h3 class="cu-label">
                                  <label>Vacation Days :</label>
                                </h3>
                                <div class="cu-input text-box">
                                  <span class="fa fa-edit"></span>
                                  {{ vacRequest.Total_Days }} days
                                </div>
                              </div>
                              <!-- Request Date -->
                              <div class="cu-field col-md-6">
                                <h3 class="cu-label">
                                  <label>The Date Of The Request :</label>
                                </h3>
                                <div class="cu-input text-box">
                                  <span class="fa fa-edit"></span>
                                  {{ vacRequest.Entry_date.split("T")[0] }}
                                </div>
                              </div>
                            </div>
                          </div>

                          <!-- Emergency cases -->
                          <div
                            class="cu-form-group special shadow-sm grouped rounded mb-3 bg-light pr-3 pl-3"
                          >
                            <div class="row">
                              <div class="cu-field col-md-12">
                                <h3 class="cu-label">
                                  <label
                                    >In case of emergency, We can we cotact you by
                                    :</label
                                  >
                                </h3>
                                <div class="cu-input text-box" style="max-width: 100%">
                                  <span class="fa fa-edit"></span>
                                  {{ vacRequest.Emergency_Contact }}
                                </div>
                              </div>
                            </div>
                          </div>

                          <!-- Attached File -->
                          <div
                            class="cu-form-group special shadow-sm grouped rounded mb-3 bg-light pr-3 pl-3"
                          >
                            <div class="row">
                              <div class="cu-field col-md-12">
                                <h3 class="cu-label">
                                  <label>Attached File :</label>
                                </h3>
                                <div class="cu-input text-box" style="max-width: 100%">
                                  <span class="fa fa-edit"></span>
                                  {{ vacRequest.Attach_File }}
                                </div>
                              </div>
                            </div>
                          </div>

                          <!-- requester comment -->
                          <div
                            class="cu-form-group special shadow-sm grouped rounded mb-3 bg-light pr-3 pl-3"
                          >
                            <div class="row">
                              <div class="cu-field col-md-12">
                                <h3 class="cu-label">
                                  <label>Requester Comment :</label>
                                </h3>
                                <div class="cu-input text-box" style="max-width: 100%">
                                  <span class="fa fa-edit"></span>
                                  {{ vacRequest.Requester_Comment }}
                                </div>
                              </div>
                            </div>
                          </div>
                        </div>

                        <div id="requester-history" class="general info tabcontent">
                          <div class="col-md-12 graph">
                            <table
                              class="table table-bordered text-center shadow-sm shadow"
                            >
                              <thead class="bg-light text-dark">
                                <tr>
                                  <th scope="col">#</th>
                                  <th scope="col">Type</th>
                                  <th
                                    scope="col"
                                    v-show="
                                      HR_Vacations_Period.filter(
                                        (x) =>
                                          x.Request_id == vacRequest.id &&
                                          x.Date_from == x.Date_to
                                      ).length > 0
                                    "
                                  >
                                    Requested Dates
                                  </th>
                                  <th
                                    scope="col"
                                    v-show="
                                      HR_Vacations_Period.filter(
                                        (x) =>
                                          x.Request_id == vacRequest.id &&
                                          x.Date_from == x.Date_to
                                      ).length == 0
                                    "
                                  >
                                    Start
                                  </th>
                                  <th
                                    scope="col"
                                    v-show="
                                      HR_Vacations_Period.filter(
                                        (x) =>
                                          x.Request_id == vacRequest.id &&
                                          x.Date_from == x.Date_to
                                      ).length == 0
                                    "
                                  >
                                    End
                                  </th>
                                  <th
                                    scope="col"
                                    class="d-none"
                                    v-show="
                                      HR_Vacations_Period.filter(
                                        (x) =>
                                          x.Request_id == vacRequest.id &&
                                          x.Date_from == x.Date_to
                                      ).length > 0
                                    "
                                  >
                                    Status
                                  </th>
                                  <th scope="col">Status</th>
                                </tr>
                              </thead>

                              <tbody class="bg-white">
                                <tr
                                  v-for="(request, i) in allVacRrq.filter(
                                    (x) => x.Requester_id == vacRequest.Requester_id
                                  )"
                                  :key="request.id"
                                >
                                  <th scope="row">{{ i + 1 }}</th>
                                  <td>{{ request.Vacation_Type_name }}</td>
                                  <td
                                    scope="col"
                                    v-show="
                                      HR_Vacations_Period.filter(
                                        (x) =>
                                          x.Request_id == vacRequest.id &&
                                          x.Date_from == x.Date_to
                                      ).length > 0
                                    "
                                  >
                                    {{
                                      HR_Vacations_Period.filter(
                                        (x) => x.Request_id == request.id
                                      )
                                        .map((x) => x.Date_from)
                                        .join()
                                        .replace(/,/g, "  ,  ")
                                    }}
                                  </td>
                                  <td
                                    scope="col"
                                    v-show="
                                      HR_Vacations_Period.filter(
                                        (x) =>
                                          x.Request_id == vacRequest.id &&
                                          x.Date_from == x.Date_to
                                      ).length == 0
                                    "
                                  >
                                    {{
                                      HR_Vacations_Period.filter(
                                        (x) => x.Request_id == request.id
                                      )[0].Date_from
                                    }}
                                  </td>
                                  <td
                                    scope="col"
                                    v-show="
                                      HR_Vacations_Period.filter(
                                        (x) =>
                                          x.Request_id == vacRequest.id &&
                                          x.Date_from == x.Date_to
                                      ).length == 0
                                    "
                                  >
                                    {{
                                      HR_Vacations_Period.filter(
                                        (x) => x.Request_id == request.id
                                      )[0].Date_to
                                    }}
                                  </td>
                                  <td
                                    scope="col"
                                    class="d-none"
                                    v-show="
                                      HR_Vacations_Period.filter(
                                        (x) =>
                                          x.Request_id == vacRequest.id &&
                                          x.Date_from == x.Date_to
                                      ).length > 0
                                    "
                                  >
                                    {{ request.Date_to }}
                                  </td>
                                  <td v-if="request.Status == 1" class="text-primary">
                                    requested
                                  </td>
                                  <td
                                    v-else-if="request.Status == 2"
                                    class="text-success"
                                  >
                                    Accepted from manger
                                  </td>
                                  <td v-else-if="request.Status == 3" class="text-danger">
                                    Rejected from manger
                                  </td>
                                  <td
                                    v-else-if="request.Status == 4"
                                    class="text-success"
                                  >
                                    Accepted from HR
                                  </td>
                                  <td v-else-if="request.Status == 5" class="text-danger">
                                    Rejected from HR
                                  </td>
                                </tr>
                              </tbody>
                            </table>
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
      <!-- end details popup -->
    </div>
  </div>
</template>

<script>
export default {
  name: "hr",
  data() {
    return {
      adminusersData: [],
      HR_Vacation_Type: [],
      allVacRrq: [],
      VacRrq: null,

      Unpaid: [],

      WorkRequests: [],
      Employees_Balance: [],
      HR_Vacations_Period: [],

      vacRequest: [],
      activeType: "Annual",
      apiUrl: "http://localhost:56438/app/dist/",
    };
  },

  methods: {
    popUp: function (req, popName) {
      let that = this;
      req["detailsPop"] = false;
      req[popName] = true;
      this.vacRequest = Object.assign({}, req);

      setTimeout(function () {
        $("." + popName).addClass("active");
      }, 500);
      $.ajax({
        type: "POST",
        url: that.apiUrl + "Hr_Portal/Hr.aspx/checkBalance",
        data: JSON.stringify({ detail: { Emp_id: that.vacRequest.Requester_id } }),
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
          that.Employees_Balance = JSON.parse(data.d)[0];
        },
      });
    },

    close: function () {
      this.vacRequest = false;
    },

    updateWorkStatus: function (id, status, requester, dateTo) {
      let that = this;

      // approve
      if (status == 4) {
        swal({
          title: "Are you sure?",
          buttons: true,
        }).then((confirm) => {
          if (confirm) {
            let ExpirationDate = new Date(
              new Date(dateTo.trim()).getTime() + 31 * 24 * 60 * 60 * 1000
            )
              .toISOString()
              .substr(0, 10);
            $.ajax({
              type: "POST",
              url: that.apiUrl + "Hr_Portal/Hr.aspx/checkBalance",
              data: JSON.stringify({ detail: { Emp_id: requester } }),
              contentType: "application/json; charset=utf-8",
              dataType: "json",
              success: function (data) {
                that.Employees_Balance = JSON.parse(data.d)[0];
                if (data.d.length > 0) {
                  let OffBalance = that.Employees_Balance.Off_Balance;

                  // render buttons in time
                  that.WorkRequests.filter((x) => x.id == id)[0].Status = status;
                  $.ajax({
                    type: "POST",
                    url: that.apiUrl + "Hr_Portal/Hr.aspx/updateStatus",
                    data: JSON.stringify({
                      detail: { id: id, Status: status, ExpirationDate: ExpirationDate },
                    }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                  });

                  $.ajax({
                    type: "POST",
                    url: that.apiUrl + "Hr_Portal/Hr.aspx/updateOffDays",
                    data: JSON.stringify({
                      detail: { Emp_id: requester, Off_Balance: OffBalance + 1 },
                    }),
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                  });
                }
              },
            });
          }
        });

        // reject
      } else if (status == 5) {
        swal({
          title: "Are you sure?",
          icon: "warning",
          buttons: true,
          dangerMode: true,
        }).then((willReject) => {
          if (willReject) {
            swal({
              title: "Reason Of Rejection",
              content: "input",
              showCancelButton: true,
            }).then(function (reason) {
              if (reason.trim()) {
                $.ajax({
                  type: "POST",
                  url: that.apiUrl + "Hr_Portal/Hr.aspx/Rejection",
                  data: JSON.stringify({
                    request: { HR_Comment: reason, id: id, Status: status },
                  }),
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  success: function () {
                    // render buttons in time
                    that.WorkRequests.filter((x) => x.id == id)[0].Status = status;
                  },
                });
              } else {
                swal({
                  title: "Canceled",
                  text: "You did not write any reason!",
                });
              }
            });
          }
        });
      }
    },

    // a method for checking the expiration date
    checkDay: function (exp, day) {
      return (new Date(exp) - new Date(day)) / (24 * 60 * 60 * 10000) >= 0;
    },

    updateVacStatus: function (id, status, requester) {
      let that = this,
        type = that.allVacRrq.filter((x) => x.id == id)[0].Vacation_Type_name.trim(),
        offDays = 0;

      // approve
      if (status == 4) {
        swal({
          title: "Are you sure?",
          buttons: true,
        }).then((confirm) => {
          if (confirm) {
            // render buttons in time
            //that.allVacRrq.filter(x => x.id == id)[0].Status = status;

            // check dates with off day
            if (type == "OFFDayes") {
              $.ajax({
                type: "POST",
                url: that.apiUrl + "Hr_Portal/Hr.aspx/checkBalance",
                data: JSON.stringify({ detail: { Emp_id: requester } }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                  that.Employees_Balance = JSON.parse(data.d)[0];
                  if (data.d.length > 0) {
                    offDays = 1;
                    updateBalance();
                  } else {
                    swal({
                      title: "No Balance Found!",
                      text:
                        "Sorry, there was a problem finding the balance for this employee!",
                      icon: "warning",
                      dangerMode: true,
                    });
                    return false;
                  }
                },
              });
            } else if (type == "Annual" || type == "Casual") {
              $.ajax({
                type: "POST",
                url: that.apiUrl + "Hr_Portal/Hr.aspx/checkBalance",
                data: JSON.stringify({ detail: { Emp_id: requester } }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function (data) {
                  that.Employees_Balance = JSON.parse(data.d)[0];
                  if (data.d.length > 0) {
                    let totalBalance = that.Employees_Balance.Annual_Balance,
                      casualBalance = that.Employees_Balance.Casual_Balance,
                      Days = that.HR_Vacations_Period.filter(
                        (x) => x.Request_id == id
                      ).map((x) => x.Date_from),
                      DaysNum = Days.length,
                      expOldBalance =
                        that.Employees_Balance["Old_Balance_ExpirationDate"],
                      minusOldBalance = that.Employees_Balance["Old_Balance"],
                      today = new Date().toISOString().substring(0, 10),
                      currentMonth = new Date().getMonth() + 1;

                    // if the type is annual check the days that before the expiration date of the old balance
                    if (that.checkDay(expOldBalance, today) && type == "Annual") {
                      for (let i = 0; i < Days.length; i++) {
                        if (
                          that.checkDay(expOldBalance, Days[i]) &&
                          minusOldBalance > 0
                        ) {
                          minusOldBalance--;
                          DaysNum--;
                        }
                      }
                      that.Employees_Balance["Old_Balance"] = minusOldBalance;
                      if (DaysNum == 0) {
                        updateBalance();
                      }
                    }

                    // if the old balance is not enough we start decrease the totalBalance
                    if (DaysNum > 0) {
                      if (currentMonth < 4) {
                        // q1
                        let total = that.Employees_Balance["Q1"];
                        decrease(total, 1);
                      } else if (currentMonth < 7) {
                        // q2
                        let total =
                          that.Employees_Balance["Q1"] + that.Employees_Balance["Q2"];
                        decrease(total, 2);
                      } else if (currentMonth < 10) {
                        // q3
                        let total =
                          that.Employees_Balance["Q1"] +
                          that.Employees_Balance["Q2"] +
                          that.Employees_Balance["Q3"];
                        decrease(total, 3);
                      } else {
                        // q4
                        let total =
                          that.Employees_Balance["Q1"] +
                          that.Employees_Balance["Q2"] +
                          that.Employees_Balance["Q3"] +
                          that.Employees_Balance["Q4"];
                        decrease(total, 4);
                      }
                    }

                    //decreasing the balance
                    function decrease(total, numOfq) {
                      // if the vacation is casual
                      if (type == "Casual") {
                        if (DaysNum > casualBalance || DaysNum > total) {
                          alert();
                        } else {
                          // check if the requester had requested casual vacation more than two times in the same month
                          $.ajax({
                            type: "POST",
                            url: that.apiUrl + "Hr_Portal/Hr.aspx/getPeriodsData",
                            data: JSON.stringify({ detail: { Emp_id: requester } }),
                            contentType: "application/json; charset=utf-8",
                            dataType: "json",
                            success: function (data) {
                              let Dates = JSON.parse(data.d).map((x) => x["Date_from"]);
                              if (Dates.length == 0) {
                                decQ();
                              }
                              for (let i = 0; i < Days.length; i++) {
                                let month = new Date(Days[i]).getMonth() + 1;

                                if (
                                  Dates.filter(
                                    (x) => new Date(x.trim()).getMonth() + 1 == month
                                  ).length >= 2
                                ) {
                                  swal({
                                    title: "Not Allowed!",
                                    text:
                                      "Sorry, This Employee can't have casual vacation more than two days in the same month!",
                                    icon: "warning",
                                    dangerMode: true,
                                  });
                                  return false;
                                } else {
                                  if (i == Days.length - 1) {
                                    decQ();
                                  }
                                }
                              }
                            },
                          });
                        }
                      } else {
                        return total >= DaysNum ? decQ() : alert();
                      }

                      // decreasing the quarters
                      function decQ() {
                        if (total >= DaysNum) {
                          for (let i = 1; i <= numOfq; i++) {
                            if (DaysNum > 0) {
                              let Num = DaysNum - that.Employees_Balance["Q" + i];
                              that.Employees_Balance["Q" + i] =
                                that.Employees_Balance["Q" + i] < DaysNum
                                  ? 0
                                  : that.Employees_Balance["Q" + i] - DaysNum;
                              DaysNum = Num;
                            } else {
                              //update balance
                              updateBalance();
                              return false;
                            }
                          }
                          if (DaysNum <= 0) {
                            updateBalance();
                          }
                        } else {
                          alert();
                        }
                      }
                    }

                    //alert if the balance is not enough
                    function alert() {
                      swal({
                        title: "Not Allowed!",
                        text:
                          "The current vacation balance for this Employee is not enough to accept this request!",
                        icon: "warning",
                        dangerMode: true,
                      });
                      return false;
                    }
                  } else {
                    swal({
                      title: "No Balance Found!",
                      text:
                        "Sorry, there was a problem finding the balance for this employee!",
                      icon: "warning",
                      dangerMode: true,
                    });
                    return false;
                  }
                },
              });
            } else {
              updateStatus();
            }

            //updateBalance
            function updateBalance() {
              that.Employees_Balance["Annual_Balance"] =
                that.Employees_Balance["Q1"] +
                that.Employees_Balance["Q2"] +
                that.Employees_Balance["Q3"] +
                that.Employees_Balance["Q4"];
              that.Employees_Balance["Off_Balance"] =
                that.Employees_Balance["Off_Balance"] - offDays;

              $.ajax({
                type: "POST",
                url: that.apiUrl + "Hr_Portal/Hr.aspx/updateBalance",
                data: JSON.stringify({ detail: that.Employees_Balance }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                  updateStatus();
                },
                error: function () {
                  swal({
                    title: "Error!",
                    text: "Something went wrong, Please try again later!",
                    icon: "warning",
                    dangerMode: true,
                  });
                },
              });
            }

            function updateStatus() {
              that.allVacRrq.filter((x) => x.id == id)[0].Status = status;

              $.ajax({
                type: "POST",
                url: that.apiUrl + "Hr_Portal/Hr.aspx/updateVacStatus",
                data: JSON.stringify({ detail: { id: id, Status: status } }),
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                success: function () {
                  if (type != "Annual" || type != "Casual") {
                    swal({
                      title: "Sweet!",
                      text: "You successfully approved this vacation request ...",
                      icon: "success",
                    });
                  }

                  if (that.VacRrq.filter((x) => x.id == id)[0].Vacation_Type_id == 103) {
                    let DayId = that.VacRrq.filter((x) => x.id == id)[0].OFF_Day;
                    let ExpirationDate = that.WorkRequests.filter((x) => x.id == DayId)[0]
                      .ExpirationDate;

                    // update off days
                    $.ajax({
                      type: "POST",
                      url: that.apiUrl + "Hr_Portal/Hr.aspx/updateStatus",
                      data: JSON.stringify({
                        detail: { id: DayId, Status: 8, ExpirationDate: ExpirationDate },
                      }),
                      contentType: "application/json; charset=utf-8",
                      dataType: "json",
                      success: function () {
                        swal({
                          title: "Sweet!",
                          text: "You successfully approved this vacation request ...",
                          icon: "success",
                          dangerMode: true,
                        });
                      },
                    });
                  }

                  // render buttons in time
                  that.allVacRrq.filter((x) => x.id == id)[0].Status = status;
                },
              });
            }
          }
        });
      }
      // reject
      else if (status == 5) {
        swal({
          title: "Are you sure?",
          icon: "warning",
          buttons: true,
          dangerMode: true,
        }).then((willReject) => {
          if (willReject) {
            swal({
              title: "Reason Of Rejection",
              content: "input",
              showCancelButton: true,
            }).then(function (reason) {
              if (reason.trim()) {
                $.ajax({
                  type: "POST",
                  url: that.apiUrl + "Hr_Portal/Hr.aspx/VacRejection",
                  data: JSON.stringify({
                    request: { HR_Comment: reason, id: id, Status: status },
                  }),
                  contentType: "application/json; charset=utf-8",
                  dataType: "json",
                  success: function () {
                    // render buttons in time
                    that.allVacRrq.filter((x) => x.id == id)[0].Status = status;

                    if (
                      that.VacRrq.filter((x) => x.id == id)[0].Vacation_Type_id == 103
                    ) {
                      let DayId = that.VacRrq.filter((x) => x.id == id)[0].OFF_Day;
                      let ExpirationDate = that.WorkRequests.filter(
                        (x) => x.id == DayId
                      )[0].ExpirationDate;

                      // update off days
                      $.ajax({
                        type: "POST",
                        url: that.apiUrl + "Hr_Portal/Hr.aspx/updateStatus",
                        data: JSON.stringify({
                          detail: {
                            id: DayId,
                            Status: 4,
                            ExpirationDate: ExpirationDate,
                          },
                        }),
                        contentType: "application/json; charset=utf-8",
                        dataType: "json",
                        success: function () {
                          swal({
                            title: "Sweet!",
                            text: "You successfully approved this vacation request ...",
                            icon: "success",
                            dangerMode: true,
                          });
                        },
                      });
                    }
                  },
                });
              } else {
                swal({
                  title: "Canceled",
                  text: "You did not write any reason!",
                });
              }
            });
          }
        });
      }
    },

    deleteVacRequest: function (id, hide, i) {
      let cobject = this;
      swal({
        title: "Are you sure you want to delete this vacation request?",
        icon: "warning",
        buttons: true,
        dangerMode: true,
      }).then((result) => {
        if (result) {
          $.ajax({
            type: "POST",
            url: cobject.apiUrl + "Hr_Portal/Hr.aspx/updateHide",
            data: JSON.stringify({ detail: { id: id, HR_Hide: hide } }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
              cobject.VacRrq.splice(i, 1);
              swal({
                title: "Sweet!",
                text: "You successfully deleted this vacation request ...",
                icon: "success",
                dangerMode: true,
              });
            },
          });
        } else {
          swal({
            title: "Canceled",
            text: "Sorry, you can not delete this vacation request!",
          });
        }
      });
    },

    deleteWorkRequest: function (id, hide, i) {
      let cobject = this;

      swal({
        title: "Are you sure you want to delete this work request?",
        icon: "warning",
        buttons: true,
        dangerMode: true,
      }).then((result) => {
        if (result) {
          $.ajax({
            type: "POST",
            url: cobject.apiUrl + "Hr_Portal/Hr.aspx/updateWorkHide",
            data: JSON.stringify({ detail: { id: id, HR_Hide: hide } }),
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function () {
              cobject.WorkRequests.splice(i, 1);

              swal({
                title: "Sweet!",
                text: "You successfully deleted this work request ...",
                icon: "success",
                dangerMode: true,
              });
            },
          });
        } else {
          swal({
            title: "Canceled",
            text: "Sorry, you can not delete this work request!",
          });
        }
      });
    },
  },

  created: function () {
    let cobject = this;

    //get adminusers
    $.ajax({
      type: "POST",
      url: cobject.apiUrl + "Hr_Portal/Hr.aspx/getadminusersData",
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      success: function (data) {
        cobject.adminusersData = JSON.parse(data.d);
      },
    });

    // get Vacations_Requests
    $.ajax({
      type: "POST",
      url: cobject.apiUrl + "Hr_Portal/Hr.aspx/getVacations_Requests",
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      success: function (data) {
        cobject.Vacations_Requests = JSON.parse(data.d);
        cobject.allVacRrq = cobject.Vacations_Requests.filter(
          (x) =>
            x.Hide == false &&
            (x.Status == 2 || x.Status == 4 || x.Status == 5) &&
            x.HR_Hide == false
        );
        cobject.VacRrq = cobject.Vacations_Requests.filter(
          (x) => x.Hide == false || x.HR_Hide == false
        );

        cobject.Unpaid = cobject.allVacRrq.filter(
          (x) => x.Deduction_name.trim() == "Unpaid"
        );
      },
    });

    //get Work_Request
    $.ajax({
      type: "POST",
      url: cobject.apiUrl + "Hr_Portal/Hr.aspx/getrequestsData",
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      success: function (data) {
        cobject.requests = JSON.parse(data.d);
        cobject.WorkRequests = cobject.requests.filter(
          (x) =>
            x.Status == 2 ||
            x.Status == 4 ||
            x.Status == 5 ||
            x.Status == 6 ||
            x.Status == 7 ||
            x.Status == 8 ||
            x.Canceled == false ||
            x.HR_Hide == false
        );
      },
    });

    // get HR_Vacations_Period
    $.ajax({
      type: "POST",
      url: cobject.apiUrl + "Hr_Portal/Hr.aspx/getHR_Vacations_PeriodData",
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      success: function (data) {
        cobject.HR_Vacations_Period = JSON.parse(data.d);
      },
    });

    // get HR_Vacation_Type
    $.ajax({
      type: "POST",
      url: cobject.apiUrl + "Hr_Portal/Hr.aspx/gettypesData",
      contentType: "application/json; charset=utf-8",
      dataType: "json",
      success: function (data) {
        cobject.HR_Vacation_Type = JSON.parse(data.d).filter((x) => x.Hide != true);
      },
    });
  },
};
</script>

<style scoped>
.popup .popup-body {
  top: 0;
  transform: none;
}

.number-border {
  width: 25px;
  height: 25px;
  line-height: 20px;
  border: 2px solid #fff;
  border-radius: 50%;
  color: #fff;
  text-align: center;
}
.tab-content {
  border-top: none;
  box-shadow: 0px 0px 1px rgba(0, 0, 0, 0.2);
}
.nav-tabs {
  position: relative;
  overflow: hidden;
  border-bottom: none;
}
.nav-tabs::after {
  content: "";
  position: absolute;
  width: 900px;
  height: 500px;
  border-radius: 50%;
  top: 0;
  left: 0;
  background-color: #f8f9fa;
  z-index: 1;
}
.nav-link {
  font-size: 16px;
  border: 1px solid #e0e0e0 !important;
  border-radius: 20px !important;
  margin: 10px 5px !important;
  position: relative;
  z-index: 2;
}
.nav-link.active,
.nav-link.stylish {
  border: 1px solid #b3b3b3 !important;
  box-shadow: 0 0.5rem 1rem rgba(0, 0, 0, 0.15) !important;
}
.nav-justified .nav-item {
  flex-basis: 200px;
}
/* The sidepanel menu */
.sidepanel {
  direction: ltr;
  position: relative;
  z-index: 11000;
  font-weight: 500;
  font-size: 12px;
  width: 47px;
  height: 100%;
  left: 93%;
  top: 44px;
  max-width: 85vw;
  transition: transform 0.6s;
  -webkit-perspective: 1000;
  -moz-perspective: 1000;
  -ms-perspective: 1000;
  perspective: 1000;
}
.opened {
  transform: translateX(-100%);
}

.sidepanel .panel-buttons {
  background-color: #ccc6c6 !important;
  border: 1px solid #efe9e9;
  cursor: pointer;
  z-index: 10002;
  box-shadow: -5px 0 15px -1px rgba(0, 0, 0, 0.05);

  border-top-left-radius: 6px;
  border-bottom-left-radius: 6px;
  transition: opacity 0.2s;
  padding: 5px 5px;
}
.sidepanel .panel-buttons .sub-menu {
  width: 0px;
  float: right;
  overflow: hidden;
  position: absolute;
  right: 41px;
  top: -15px;
  background-color: #fff;
}
.panel-open,
.panel-docs,
.panel-social,
.panel-theme,
.panel-others,
.panel-buy,
.panel-gdpr {
  width: 35px;
  height: 28px;
  position: relative;
  padding-bottom: 34px;
  box-shadow: 0 0.5rem 1rem rgba(0, 0, 0, 0.15);
  border: 1px solid #eeecec;
  border-radius: 2px;
  background-color: #fff;
}
.dropbtn {
  height: 32px;
  color: darkgreen;
}
.panel-buttons i {
  position: relative;
  top: 5px;
  left: 9px;
  color: #cd1d1d;
  font-size: 24px;
}
.sidepanel .panel-theme .item a {
  width: 162px;
  font-size: 20px;
  padding: 4px 10px;
  min-width: 160px;
}

.sidepanel ol {
  list-style-type: none;
  margin: 0 auto;
  padding: 0;
}
.sidepanel > ol {
  max-width: 1000px;
  padding: 0 2rem;
  display: flex;
}
.sidepanel > ol > .menu-item {
  flex: 1;
  padding: 0.75rem 0;
}
.sidepanel > ol > .menu-item:after {
  position: absolute;
  width: 4px;
  height: 4px;
  border-radius: 50%;
  bottom: 5px;
  left: calc(50% - 2px);
  background: #feceab;
  will-change: transform;
  transform: scale(0);
  transition: transform 0.2s ease;
}
.sidepanel > ol > .menu-item:hover:after {
  transform: scale(1);
}

.sidepanel .item a {
  display: block;
}

.sidepanel .item a .else {
  position: relative;
  font-size: 18px;
}

.sidepanel .panel-theme .item {
  min-width: 160px;
  border-radius: 5px;
  width: 267px;
  box-shadow: 0 0.5rem 1rem rgba(0, 0, 0, 0.15);
  border: 1px solid #b7b3b3;
  display: flex;
  justify-content: space-between;
  margin-bottom: 3px;
}

.sidepanel .sub-menu .item span {
  font-size: 20px;
  border-radius: 6px;
  padding: 3px;
  margin: 2px;
  text-align: center;
  box-shadow: 0 0.5rem 1rem rgba(0, 0, 0, 0.15);
  border: 1px solid #eeecec;
  background-color: #1ca963;
  color: #fff;
}

.menu-item {
  position: relative;
}

/* start Hr*/
.hr-portal .candidates-img img {
  max-width: 90px;
}
.hr-portal .candidates-list-desc {
  overflow: hidden;
}

.hr-portal .candidates-right-details {
  position: absolute;
  top: 0;
  right: 20px;
}

.hr-portal .candidates-item-desc {
  margin-left: 30px;
  width: 90%;
}

.hr-portal .list-grid-item {
  border: 1px solid #ececec;
  border-radius: 6px;
  -webkit-transition: all 0.5s;
  transition: all 0.5s;
}

.hr-portal .list-grid-item:hover {
  -webkit-box-shadow: 0 0 20px 0px rgba(47, 47, 47, 0.09);
  box-shadow: 0 0 20px 0px rgba(47, 47, 47, 0.09);
  -webkit-transition: all 0.5s;
  transition: all 0.5s;
  border-color: transparent;
}
.hr-portal .param {
  display: flex;
  margin-top: 7px;
}
.hr-portal .param dt {
  margin-right: 10px;
}
.hr-portal .param dd {
  margin-bottom: 0px;
}
@media (max-width: 991.98px) {
  .sidepanel {
    left: 86%;
    top: 51px;
  }
  .hr-portal .fortab .tab-content {
    padding: 0 0 30px 0;
  }
  .hr-portal .candidates-img {
    text-align: center;
    display: flex;
    justify-content: center;
    float: none !important;
    margin-right: 0 !important;
  }
  .hr-portal .candidates-list-desc {
    text-align: center;
  }
  .hr-portal .param {
    display: flex;

    justify-content: center;
  }
  .hr-portal .forleft,
  .hr-portal .forright {
    float: none !important;
  }
}

@media (max-width: 767.98px) {
  .hr-portal .param.two {
    margin-top: -7px;
  }
}

@media (max-width: 575.98px) {
  .hr-portal .param {
    justify-content: center;
  }
  .hr-portal .candidates-list-desc {
    text-align: center;
  }
  .hr-portal .candidates-img {
    display: flex;
    justify-content: center;
    margin-right: 0 !important;
    float: none !important;
  }
}
</style>
