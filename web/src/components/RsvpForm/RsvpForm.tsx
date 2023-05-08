import React, { useEffect, useState } from "react"

interface RsvpFormProps {
  guestId: string | undefined
  contactUs: string
}

const formIds = {
  rsvpSelection: "rsvpSelection",
  phoneNumber: "phoneNumber"
}

const RsvpForm = ({ guestId, contactUs }: RsvpFormProps) => {

  const [rsvp, setRsvp] = useState<string | undefined>(undefined);
  const [phoneNumber, setPhoneNumber] = useState<string>("");
  const [message, setMessage] = useState<string>("");
  const [parentsWelcome, setParentsWelcome] = useState<string | undefined>(undefined);

  const [errors, setErrors] = useState<Map<string, string>>(new Map());

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
        error.set(formIds.rsvpSelection, "RSVP is required")
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

  const handleSubmit = () => {
    if (!areThereAnyErrors()) {
      console.log(JSON.stringify(errors));
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
            <input type="tel" placeholder="" onChange={handleNumberChange} value={phoneNumber} className={`input input-bordered ${isValid(formIds.phoneNumber) || 'input-error'}`} />

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
        </div>

        {parentsAreWelcome}

        <div className="form-control w-full max-w-xs">
          <label className="label">
            <span className="label-text">Message</span>
          </label>
          <textarea className="textarea textarea-bordered h-24" onChange={handleMessageChange} value={message} placeholder="Type here"></textarea>
        </div>

        <button className="btn w-full max-w-xs mt-2" onClick={handleSubmit}>Submit</button>

        <p className="italic">If any problem, contact us: {contactUs}</p>

      </div>
    </div>
  )
};

export default RsvpForm;