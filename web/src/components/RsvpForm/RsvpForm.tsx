import React, { useEffect, useState } from "react"
import { ToastContainer, toast } from 'react-toastify';
import 'react-toastify/dist/ReactToastify.css';
import PartyTrackerClient from "../../services/api/PartyTracker";

interface RsvpFormProps {
  guestId: string,
  phoneNumber: string | undefined,
  rsvp: string | undefined,
  parents: string | undefined
  contactUs: string
}

const formIds = {
  rsvpSelection: "rsvpSelection",
  phoneNumber: "phoneNumber"
}

const RsvpForm = ({ guestId, phoneNumber: phoneNumberProp, rsvp: rsvpProp, parents: parentsProp, contactUs }: RsvpFormProps) => {

  const [rsvp, setRsvp] = useState<string | undefined>(rsvpProp);
  const [phoneNumber, setPhoneNumber] = useState<string>(phoneNumberProp ?? "");
  const [message, setMessage] = useState<string>("");
  const [parentsWelcome, setParentsWelcome] = useState<string | undefined>(parentsProp);

  const [errors, setErrors] = useState<Map<string, string>>(new Map());
  const [isLoading, setIsLoading] = useState<boolean>(false);
  const [errorAlert, setErrorAlert] = useState<boolean>(false);

  useEffect(() => {
    const deleteError = () => {
      var newError = new Map(errors);
      newError.delete(formIds.rsvpSelection);
      setErrors(newError);
    }

    if (rsvp?.includes("Declines"))
      setParentsWelcome(undefined);

    if (errors.has(formIds.rsvpSelection))
      deleteError();
  }, [rsvp]);

  useEffect(() => {
    const deleteError = () => {
      var newError = new Map(errors);
      newError.delete(formIds.phoneNumber);
      setErrors(newError);
    }

    if (errors.has(formIds.phoneNumber))
      deleteError();
  },
    [phoneNumber]);

  const areThereAnyErrors = (): boolean => {
    const validateRsvp = (value: string | undefined, error: Map<string, string>) => {
      if (!value)
        error.set(formIds.rsvpSelection, "RSVP selection is required")
    }

    const validatePhoneNumber = (value: string, error: Map<string, string>) => {
      if (value.length !== 10)
        error.set(formIds.phoneNumber, "Please use a valid phone number")
    }

    const errorMap = new Map<string, string>();

    validateRsvp(rsvp, errorMap);
    validatePhoneNumber(phoneNumber, errorMap);

    setErrors(errorMap);
    return errorMap.size > 0;
  }

  const handleNumberChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const input = e.target.value.replace(/\D/g, "");

    setPhoneNumber(input);
  }

  const handleRsvpChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    setRsvp(e.currentTarget.value);
  }

  const handleParentsWelcomeChange = (e: React.ChangeEvent<HTMLSelectElement>) => {
    setParentsWelcome(e.currentTarget.value);
  }

  const handleMessageChange = (e: React.ChangeEvent<HTMLTextAreaElement>) => {
    const input = e.target.value.replace(/[^a-zA-Z\s',.!?:;\-\d]/g, "");
    const limitedInput = input.substring(0, 250);
    setMessage(limitedInput);
  }

  const isValid = (formId: string): boolean => {
    if (errors.get(formId))
      return false;

    return true;
  }

  const errroMessage = (formId: string): string => {
    if (errors.has(formId))
      return errors.get(formId) ?? "";

    return "";
  }

  const errorBanner = <div className="alert alert-error shadow-lg">
    <div>
      <svg xmlns="http://www.w3.org/2000/svg" className="stroke-current flex-shrink-0 h-6 w-6" fill="none" viewBox="0 0 24 24"><path strokeLinecap="round" strokeLinejoin="round" strokeWidth="2" d="M10 14l2-2m0 0l2-2m-2 2l-2-2m2 2l2 2m7-2a9 9 0 11-18 0 9 9 0 0118 0z" /></svg>
      <span>Error! Please contact us or try again.</span>
    </div>
  </div>

  const handleSubmit = async () => {
    if (!areThereAnyErrors()) {
      setErrorAlert(false);
      try {
        setIsLoading(true);
        const request: IGuestInfo = {
          id: guestId,
          name: "",
          phoneNumber: phoneNumber,
          rsvp: rsvp,
          parents: parentsWelcome,
          message: message
        }

        const response = await PartyTrackerClient.updateGuestInfo(request);
        toast.success("Thanks for your response!" ,{ autoClose: 3000, bodyClassName: "alert-success", position: "bottom-center", theme: "colored" });
      } catch (e) {
        console.log(e);
        setErrorAlert(true);
      } finally {
        setIsLoading(false);
      }
    }
  }

  const parentsAreWelcome = (rsvp?.includes("Accepts")) ? <div className="form-control w-full max-w-xs">
    <label className="label">
      <span className="label-text">Parents are welcome</span>
      <span className="label-text-alt">Are you joining us?</span>
    </label>
    <select className="select select-bordered" onChange={handleParentsWelcomeChange} value={parentsWelcome ?? ""}>
      <option disabled value="">Pick one</option>
      <option>Yes</option>
      <option>No</option>
      <option>Maybe</option>
    </select>
  </div> : <></>

  return (
    <div className="card card-compact w-94 bg-base-100 shadow-xl mt-3">
      <div className="card-body items-center text-center">
        <h2 className="card-title">RSVP</h2>

        <div className="form-control  w-full max-w-xs">
          <label className="input-group">
            <span>Phone #</span>
            <input type="tel" placeholder="Your Phone Number" onChange={handleNumberChange} value={phoneNumber} className={`input input-bordered ${isValid(formIds.phoneNumber) || 'input-error'}`} />
          </label>
          <label className="label">
            <span className="label-text-alt text-red-500">{errroMessage(formIds.phoneNumber)}</span>
          </label>
        </div>

        <div className="form-control w-full max-w-xs">
          <label className="label">
            <span className="label-text">RSVP</span>
          </label>
          <select className={`select select-bordered ${isValid(formIds.rsvpSelection) || 'select-error'}`} onChange={handleRsvpChange} value={rsvp ?? ""}>
            <option disabled value="">Pick one</option>
            <option>Accepts with Pleasure</option>
            <option>Declines with Regrets</option>
          </select>
          <label className="label">
            <span className="label-text-alt text-red-500">{errroMessage(formIds.rsvpSelection)}</span>
          </label>
        </div>

        {parentsAreWelcome}

        <div className="form-control w-full max-w-xs">
          <label className="label">
            <span className="label-text">Message</span>
          </label>
          <textarea className="textarea textarea-bordered h-24" onChange={handleMessageChange} value={message} placeholder="Type here"></textarea>
        </div>

        <button className={`btn w-full max-w-xs mt-2 ${!isLoading || 'loading'}`} onClick={handleSubmit}>{isLoading || 'Submit'}</button>

        {errorAlert ? errorBanner : <></>}


        <p className="italic">If any problem, contact us: {contactUs}</p>



      </div>
      <ToastContainer />
    </div>
  )
};

export default RsvpForm;